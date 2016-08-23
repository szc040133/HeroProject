#解析protobufs里面xls类
import os
import json
import collections
import configparser
import xlrd
import itertools
import functools
from utils import ConfigPath
import time

class ArrayDict(collections.OrderedDict):
    def __missing__(self, k):
        self[k] = []
        return self[k]
class Default(dict):
    def __missing__(self, key):
        return key
eval_env = Default()
list_fmt = "[{}]".format
dict_fmt = "{{{}}}".format
dump_sorted = functools.partial(json.dumps, ensure_ascii=False,separators = (",", ": "),sort_keys=True, indent=4)
                             
class ProtoXLS:
    global xls_tasks
    global json_outputs
    global types
    global uniq_tasks
    global sort_tasks
    global ref_file_tasks
    
    xls_tasks =ArrayDict()
    json_outputs = ArrayDict()
    uniq_tasks = ArrayDict()
    sort_tasks = ArrayDict()
    ref_file_tasks = ArrayDict()
    
    types = {
    "int": int,
    "float": float,
    "str": str,
    "bool": bool,
    "list": lambda raw: eval(list_fmt(raw), None, eval_env),
    "dict": lambda raw: eval(dict_fmt(raw), None, eval_env),
    }
        
    
    def __init__(self,currPath='',xlsPath=''):
        self.currPath = currPath
        self.xlsPath = xlsPath
        self.progress = collections.OrderedDict.fromkeys(["xls", "sheet", "column", "row", "output"])
        self.types_recorder = collections.defaultdict(dict)
        self.xlsData = {}
    
    def readConfig(self): #读取模板配置信息
        cfg = configparser.ConfigParser()
        path = os.path.join(self.currPath,"tempfile\\config")
        cfg.read(path,"utf-8")
        for i in cfg.sections():
            for j in cfg[i]:
                xls_tasks[cfg[i][j]].append([i, j]) #信息结构  ArrayDict([('protobuffs', [['proto.xls', 'id_name']])])
               
                
    def readType(self): #读取类型信息
        typesPath = os.path.join(self.currPath,"tempfile\\types_recorder")
        if os.path.exists(typesPath):
            with open(typesPath, encoding="utf-8") as f:
                self.types_recorder.update(json.load(f))
        
    def start(self):
        self.readConfig()
        self.setxls()
        self.readType()
        

    def setxls(self):
        for k, v in xls_tasks.items():
            self.progress["output"] = k  #protobuffs
            for xls, sheet in v: #proto.xls ,id_name
                self.progress["xls"] = xls
                self.progress["sheet"] = sheet
        
    def parse(self):
        xls = self.progress["xls"]
        sheet = self.progress["sheet"]
        #key = self.progress["output"]
        sheetData = xlrd.open_workbook("{}/{}".format(self.xlsPath, xls)).sheet_by_name(sheet)
        self.xlsData["data"]= sheetData #存取xls里面的数据
        #json_outputs[key].extend(parse_sheet(sheet))#{'message': 'cs_login', 'is_crypto': 0, 'module': 'login', 'id': 1, 'is_compress': 0}
        #return parse_sheet(sheet)# 一个表里面的sheet所有数据
    def note_text_to_attr(self,text):
        attr = {}
        for line in filter(None, (_.strip() for _ in text.split("\n"))):
            token = line.split(":", 1)
            if len(token) != 2:
                continue
            k, v = (_.strip() for _ in token)
            attr[k] = v
        return attr
    
    def get_keys_attrs(self):
        sheetData = self.xlsData["data"]
        self.progress["row"] = 1
        #计算第一行的keys值
        keys = list(itertools.takewhile(lambda x: isinstance(x, str) and x,sheetData.row_values(0)))     
        assert keys, self.progress #判断真假，必须为真
        assert len(set(keys)) == len(keys), keys
        attrs = []
        cell_note_map = sheetData.cell_note_map
        for colx in range(len(keys)):
            colname = xlrd.colname(colx) # 表的列书 A B C D 
            self.progress["column"] = colname
            note = cell_note_map.get((0, colx))
            txt = note.text
            out = self.note_text_to_attr(txt)#计算每个列上面的批注的内容   取数值类型
            #print("note_text_to_attr_{}({!r}) = {}".format(colname, txt, out))
            assert "type" in out
            attrs.append(out)
        self.xlsData["keys"] = keys #['id', 'module', 'message', 'is_crypto', 'is_compress']
        self.xlsData["attrs"] = attrs #[{'type': 'int', 'uniq': 'true'}, {'type': 'str'}, {'type': 'str', 'uniq': 'true'}, {'type': 'int'}, {'type': 'int'}]
    
    def filter_cell_value(self,sheet_type,sheet_value, datemode=0):
        if sheet_type == xlrd.XL_CELL_NUMBER:
            if sheet_value.is_integer():
                sheet_value = int(sheet_value)
        elif sheet_type == xlrd.XL_CELL_DATE:
            sheet_value = xlrd.xldate_as_tuple(sheet_value, datemode)
        elif sheet_type == xlrd.XL_CELL_BOOLEAN:
            sheet_value = bool(sheet_value)
        else:
            sheet_value = sheet_value.strip()
        return sheet_value

    def parse_sheet(self):
        sheetData = self.xlsData["data"]
        rows_values = []
        for i in range(1, sheetData.nrows):
            if sheetData.row_values(i)[0] != "":
                #遍历得到每一列数据
                rows_values.append(list(map(self.filter_cell_value,sheetData.row_types(i),sheetData.row_values(i))))                         
            else:
                break
        #rows_values 没一行的数据 [1.0, 'login', 'cs_login', 0.0, 0.0, '', ''] array('B', [2, 1, 1, 2, 2, 0, 0])
        self.xlsData["rows_values"] = rows_values
    
    def apply_attrs(self,values, attrs, rowx):
        #print('行数-->  {}'.format(rowx+1))
        #attrs [{'type': 'int', 'uniq': 'true'}, {'type': 'str'}, {'type': 'str', 'uniq': 'true'}, {'type': 'int'}, {'type': 'int'}]
        #values [1, 'login', 'cs_login', 0, 0, '', '']
        fmt = "{} -> {} -> {}".format
        o = []
        colx = 0
        for x, attr in zip(values, attrs):
            colname = xlrd.colname(colx)
            self.progress["column"] = colname
            abs_colname = fmt(self.progress["xls"], self.progress["sheet"], colname) #proto.xls -> id_name -> A
            if attr:
                #
                x = types[attr["type"]](x)
                #
                if attr.get("uniq"):
                    uniq_tasks[abs_colname].append(x)
                    
            o.append(x)
            colx += 1
        return o


    def combine(self):
        keys = self.xlsData["keys"]
        attrs = self.xlsData["attrs"]
        rows_values = self.xlsData["rows_values"] #每一行的数据
        o = []
        for rowx, values in enumerate(rows_values, 1):
            self.progress["row"] = rowx + 1   # rowx行数  values每行具体数据 
            v = self.apply_attrs(values, attrs, rowx) #每行id数据
            o.append(dict(zip(keys, v)))
        print(self.progress["xls"]+"--->读取完成") 
        self.types_recorder[self.progress["output"]] = dict(zip(keys, (i["type"] for i in attrs)))
        #{'module': 'str', 'id': 'int', 'is_compress': 'int', 'message': 'str', 'is_crypto': 
        json_outputs[self.progress["output"]].extend(o)
        
    def save(self):
        for k in json_outputs:
            path = '{}\\tempfile\\org\\{}'.format(self.currPath,k)
            with open(path, "w", encoding="utf-8") as f:
                f.write(dump_sorted(json_outputs[k]))
         
        for k, v in json_outputs.items():
            path = '{}\\tempfile\\{}'.format(self.currPath,k)
            with open(path, "w", encoding="utf-8") as f:
                assert v
                f.write(dump_sorted(v))
        
        typePath = os.path.join(self.currPath,"tempfile\\types_recorder")
        with open(typePath, "w", encoding="utf-8") as f:
            f.write(dump_sorted(self.types_recorder))
        
    def run(self):
        self.start()
        time.sleep(0.2)
        self.parse()
        self.get_keys_attrs()
        self.parse_sheet()
        self.combine()
        self.save()
        
if __name__ == "__main__":
    currPath= os.getcwd()
    config = ConfigPath.Config('E:\Wrok\Python')
    TotalPath = config.get_TotalPath()
    xlsPath = config.get_ProXlsPath()
    os.chdir(TotalPath) #切换目录
    xls = ProtoXLS(currPath,xlsPath)
    xls.run()
    
