#xls解析类
import glob
from utils import AlertView
import collections
import xlrd
import itertools
import re
import os
from localdatatool import CheckResource, CheckLua
from localdatatool import LocalxlsTypes
import functools
import json

class ListDefaultDict(collections.OrderedDict):
    def __missing__(self, k):
        self[k] = []
        return self[k]
    
#全局变量
KEY_ROW = 0
START_COL = 1 #开始，列
TYPE_ROW = 2 #类型，行
START_ROW = 3 #开始，行
uniq_tasks = ListDefaultDict()  #唯一字段检测
sort_tasks = ListDefaultDict()  #排序字段检测
json_outputs = ListDefaultDict() #最后输出的总数据
lua_tasks = {}    #lua任务
check_file_tasks ={} #检测资源
dump_sorted = functools.partial(json.dumps, ensure_ascii=False, separators = (",", ": "),sort_keys=True, indent=4)  #导出设置格式
class paresxls:
    def __init__(self,xlsPath=''):
        self.xlsPath=xlsPath
        self.xls_tasks = [] #存取所有的xls文件
        self.progress = collections.OrderedDict.fromkeys(["xls", "sheet", "column", "row", "output"])   #xls结构
        self.types_recorder = collections.defaultdict(dict)
        
    #打开表文件 
    def open_flie_xls(self):
        path = "{}/*.xls".format(self.xlsPath) #xls的文件路径
        for file in glob.glob(path):
            if file.find("~$")<=0 : #排除一些临时文件。用wps打开表的时候会产生临时文件
                self.xls_tasks.append(file)
                
        if len(self.xls_tasks) == 0 :
            AlertView.Window(self.xlsPath+'文件夹为空').run() #弹出提示框
            exit() #停止代码执行  退出程序
    #初始化数据          
    def init_data(self): 
        for xls in self.xls_tasks:
            self.parse_xls(xls)
            
    #解析单独一个xls文件    
    def parse_xls(self,xls): 
        self.progress["xls"] = xls
        for sheet in xlrd.open_workbook(xls).sheets():
            try:
                sheet_name = sheet.row_values(KEY_ROW)[KEY_ROW] #表名 [0,0]位置是死的
            except IndexError:
                continue
            if sheet_name:
                print("parse_sheet---->{} - {} to {}".format(xls, sheet.name, sheet_name))
                self.progress["sheet"] = sheet.name
                self.progress["column"] = None
                self.progress["row"] = None
                self.progress["sheet_name"] = sheet_name
                self.parse_sheet(sheet_name, sheet)
                
    #解析表--单个工作表的数据 如 VipConfig这个张工作表的数据        
    def parse_sheet(self,sheet_name,sheet):
        #得到key和对应的类型 key_list['id']--->type_list['int']
        key_list, type_arr = self.get_keys_and_types(sheet)
        type_list = [i["type"] for i in type_arr]
    
        #检测是否有工作表名重复
        if json_outputs.get(sheet_name):
            msg = "该表名已经存在  {{{}}}\n请修改表名再到表".format(sheet_name)
            AlertView.Window(msg).run() #弹出提示框
            raise RuntimeError
        else:
            self.types_recorder[sheet_name] = dict(zip(key_list, type_list))
          
        #计算一下一共有多少行数据 END表示结尾
        endindex = 0
        for i in range(START_ROW, sheet.nrows): #找到第一个结束的行
            if sheet.row_values(i)[0] == "END":
                endindex=i+1
                break
             
        all_sheet_rows_values = [] #整一张工作表，所有行的数据
        for i in range(START_ROW, endindex): #遍历行数
            if sheet.row_values(i)[START_COL] != None and sheet.row_values(i)[START_COL] != "": #sheet.row_types(i)获取单元格内容的数据类型
                all_sheet_rows_values.append(list(map(self.filter_cell_value,sheet.row_types(i)[START_COL:],sheet.row_values(i)[START_COL:])))                               
            else:
                break
         
        self.progress["column"] = START_COL
        self.progress["row"] = None
        key_values = [i[0] for i in all_sheet_rows_values] #第一列ID列 计算是否有重复的id
        if len(set(key_values)) != len(key_values):
            msg=sheet_name+" 表有重复ID: " + "-->" + str(set(i for i in key_values if key_values.count(i) != 1))
            AlertView.Window(msg).run() #弹出提示框
            exit()#退出
        
        
        #type_arr--->[{'addBaseType': {}, 'type': 'int'},{'addBaseType': {'lua', 'hlaf'}, 'type': 'float'}]
        json_outputs[sheet_name].extend(self.combine_sheet(sheet_name,key_list, type_arr, all_sheet_rows_values))
        
    
    #解析一场表的key和类型 key_list['id']--->type_list['int']
    def get_keys_and_types(self,sheet):
        self.progress["row"] = KEY_ROW + 1
        #取[id]那一行的数据
        k_list = list(itertools.takewhile(lambda x: isinstance(x, str) and x,sheet.row_values(KEY_ROW+1)[START_COL:]))   
        self.check_key_repeat(k_list) #检测重复id           
        assert k_list, self.progress
        assert len(k_list) == len(set(k_list))
        consttype = LocalxlsTypes.BaseTypes().get_constType()
        sheet_name = sheet.row_values(KEY_ROW)[KEY_ROW] #表名 VipConfig
        self.progress["row"] = TYPE_ROW + 1
        #检测类型有没有配置，和类型是否配置错误
        type_list=[]
        for colx in range(START_COL,len(k_list)+1):
            colname = xlrd.colname(colx)
            self.progress["column"] = colname
            type_value_list = sheet.row_values(TYPE_ROW)[colx].split("|") #['list_int'] 没行的具体的类型值

            d = { "addBaseType" : {}} #list_str|lua 一个表格里面配置了两种类型
            if len(type_value_list) > 1:  # 第一个必须有个类型值
                dic=set(type_value_list[1:])
                d["addBaseType"]=dic #{ "addBaseType" : {'lua',half}}
                
            #检测id是否我唯一
            base_type = type_value_list[0] #int str bool 数值类型
            if not base_type:
                AlertView.Window(sheet_name+' {}行{}列没有配置类型'.format(TYPE_ROW + 1, colname)).run() #弹出提示框
                raise
            elif list(consttype.keys()).count(base_type) == 0:
                AlertView.Window(sheet_name+' {}行{}列当前没有这种数值类型'.format(TYPE_ROW + 1, colname)).run() #弹出提示框
                raise
            else:
                d["type"] = base_type
                type_list.append(d)
        
        return k_list,type_list
    
    
    #检测工作表的key是否有重复  --- 取[id]那一行的数据
    def check_key_repeat(self,key_list=[]):
        for key in key_list:
            if key_list.count(key)>1:
                AlertView.Window(self.progress["sheet_name"]+' 工作表中有重复的ID \n{{{}}}'.format(key)).run() #弹出提示框
                raise RuntimeError
    
    #设置单元格数据对象。有的单元格int是1Python解析的时候是1.0这里需要 转换一下
    def filter_cell_value(self,cell_type, value, datemode=0):
        if cell_type == xlrd.XL_CELL_NUMBER:
            if value.is_integer():
                value = int(value)
        elif cell_type == xlrd.XL_CELL_DATE:
            value = xlrd.xldate_as_tuple(value, datemode)
        elif cell_type == xlrd.XL_CELL_BOOLEAN: #单元格是bool类型，解析之后是1,0.所以需要转换
            value = bool(value)
        else:
            value = value.strip()  #除掉左右空格
        return value
    
    #组合一张工作表的数据
    def combine_sheet(self,sheet_name,key_list, type_arr, all_sheet_rows_values): #整一张工作表，所有行的数据
        o = []
        for rowx, rows_values in enumerate(all_sheet_rows_values, START_ROW):
            self.progress["row"] = rowx + 1  #表上面显示的行数 rows_values 单行数据
            v_list = self.apply_types(sheet_name,rows_values, key_list, type_arr, rowx)
            o.append(dict(zip(key_list, v_list)))
        return o
    
    def apply_types(self,sheet_name,rows_values, key_list, type_arr, rowx):
        fmt = "{} -> {} -> {}".format
        o = []
        colx = START_COL
        constType = LocalxlsTypes.BaseTypes().get_constType()
        for value, key, attr_type in zip(rows_values, key_list, type_arr):
            #print(v,'-->',key,'**>',attr)1 --> id **> {'addBaseType': {}, 'type': 'int'}
            colname = xlrd.colname(colx)
            self.progress["column"] = colname
            xls = self.progress["xls"].split('\\')
            abs_colname = fmt(xls[len(xls)-1], sheet_name, colname)
            abs_name = abs_colname +str(rowx) #VipConfig.xls -> VipConfig -> B3
            
            if attr_type:
                #检测全角和半角
                if list(attr_type["addBaseType"]).count("hlaf")>0 and isinstance(value, str):
                    value = self.set_half(value)
               
                #根据配置类型设置导出时候的不同类型的值
                value = constType[attr_type["type"]](value)
                
                #检测唯一字段
                if list(attr_type["addBaseType"]).count("uniq")>0:
                    uniq_tasks[abs_colname].append(value)
                    
                #排序字段检测
                if list(attr_type["addBaseType"]).count("sort")>0:
                    sort_tasks[abs_colname].append(value)
            
                # 检测lua
                if list(attr_type["addBaseType"]).count("lua") >0:
                    name = self.progress["sheet_name"]
                    if not lua_tasks.get(name):
                        lua_tasks[name] = {}
                    if not lua_tasks[name].get(key):
                        lua_tasks[name][key] = []
                    lua_tasks[name][key].append((value, abs_name))
                    #{'VipConfig': {'vipReward': [('Sound/BGM/Login/Main-Login.mp3', 'VipConfig.xls -> VipConfig -> D  3')]}}
                    
                #检测资源
                if list(attr_type["addBaseType"]).count("check_file") >0:
                    ref =['\\']
                    ref_dir = ref[0].format(value=value)
                    ref_file = value
                    xls = self.progress["xls"].split('\\')
                    abs_cellname = fmt(xls[len(xls)-1], sheet_name, xlrd.cellname(rowx, colx))
                    check_file_tasks[abs_cellname] = os.path.relpath(os.path.join(ref_dir, ref_file).lstrip(r"\/"))
                    #{'VipConfig.xls -> VipConfig -> D4': 'Sound\\BGM\\Login\\Main-Login.mp3'} 输出结果
                
                o.append(value)
                colx += 1
        return o
    
    def set_half(self,value):
        tag = False
        if re.findall("[^\n]\r[^\n]", value):  #左右都没有换行中间有换行的，删除掉中间的换行
            re.sub("[^\n]\r[^\n]", "", value)
            if not tag:
                tag = True
               
        if re.findall("\r[^\n]", value): #开头有换行，删除掉
            re.sub("\r[^\n]", "", value)
            if not tag:
                tag = True
               
        if re.findall("[^\n]\r$", value):#末尾有换行删除掉
            re.sub("[^\n]\r$", "", value)
            if not tag:
                tag = True
        if re.findall("^\r$", value):
            re.sub("^\r$", "", value)
            if not tag:
                tag = True
        if tag:
            print(r"这里有单元格里面有\r", value)

        value = self.strQ2B(value)
        return value
    
    #全角转半角
    def strQ2B(self,v):
        result = ""
        for c in v:
            code = ord(c)
            if code == 12288:#全角空格直接转换            
                code = 32 
            elif (code >= 65281 and code <= 65374): #全角字符（除空格）根据关系转化
                code -= 65248
            result += chr(code)
        return result
    
    #检测资源和其他
    def check_resource_and_other(self): 
        res = CheckResource.CheckRes(self.callback)
        res.set_uniq_tasks(uniq_tasks) #设置需要检测的资源数据
        res.set_sort_tasks(sort_tasks) #检测排序数据
        res.set_check_file(check_file_tasks) #设置资源文件检测数据
        res.check()
    
    #检测lua
    def check_lua(self):
        if len(lua_tasks)>0:
            checklua=CheckLua.tool(json_outputs,lua_tasks)
            checklua.check()
    
    #回调完成
    def callback(self):
        print("Loacalxls--->检测完成")
        self.save_file()
    
    #回调完成之后保存文件
    def save_file(self):
        for k, v in json_outputs.items():
            path = "{}\\tempfile\\tmp".format(os.getcwd())
            with open(os.path.join(path, k), "w", encoding="utf-8") as f:
                try:
                    assert v
                except:
                    print("要保存的数据文件 "+k+" 为空")
                    raise RuntimeError
                f.write(dump_sorted(v))
       
        path = "{}\\tempfile\\record".format(os.getcwd())
        with open(os.path.join(path, "types_recorder"), "w", encoding="utf-8") as f:
            f.write(dump_sorted(self.types_recorder))
        print("Loacalxls--->保存完成")
    
    def run(self):
        self.open_flie_xls()
        self.init_data()
        self.check_resource_and_other()
        self.check_lua()
       

# if __name__ == '__main__':
#     config = ConfigPath.Config('E:\Wrok\Python\localdatatool')
#     xls = Localxls(config.get_CS_Excel_path())
#     xls.run()