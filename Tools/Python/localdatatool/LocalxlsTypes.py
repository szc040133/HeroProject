#解析xls表里面类型类
#全局变量
import re
from utils import AlertView
import collections 
list_fmt = "[{}]".format
dict_fmt = "{{{}}}".format  #两个{{表示一个 {
find_key = re.compile(r',?(?P<key>\w+):').findall
eval_env = collections.defaultdict(dict)
class BaseTypes:
    def __init__(self,sheet_name=''):
        self.sheet_name = sheet_name
        self.const_types = {
        # 设置基本值类型
        "int": lambda raw: int(round(float(raw))),
        "int32": lambda raw: int(round(float(raw))),
        "float": float,
        "str": str,
        "bool": self.type_bool,
        "list_int":self.list_int,
        "list_str":self.list_str,
        "list_float":self.list_float,
        "dict_str_str":self.dict_str_str,
        } 
        
    def list_int(self,value):
        self.check_value_special_str(value)
        #[int(j) for j in value.strip('[]').split(',')] == '[1,2,3,4]' ----> [1,2,3,4] 转化数组
        g = lambda raw: [int(i) for i in [int(j) for j in raw.strip('[]').split(',')]]
        return g(value)
     
    def type_bool(self,Val): 
        if type(Val) == bool:
            return  bool(Val)
        elif type(Val) == str:
            if Val.lower() == "true":
                return  True
            elif Val.lower() == "false":
                return  False
            else:
                raise "配置bool类型有错"
        else:
            raise "配置bool类型有错"
    
    def list_str(self,value):
        self.check_value_special_str(value)
        v_list=value.strip('[]').split(',')
        o=[]
        for key in v_list:
            key = key.strip('\"')  #需要判断是中文的引号还是英文的英豪
            o.append(str(key))
        return o
      
      
    def list_float(self,value):
        self.check_value_special_str(value)
        g = lambda raw: [float(i) for i in [float(j) for j in raw.strip('[]').split(',')]]
        return g(value)
        
        
    def dict_str_str(self,value):
        self.check_value_special_str(value) #检测是否有配错
        value=value.strip("{}")
        key_list = find_key(value)
        if len(frozenset(key_list)) != len(key_list):
            AlertView.Window(self.sheet_name+"字典数据id:value数据不对应\n"+value).run() #弹出提示框
            raise RuntimeError
        return eval(dict_fmt(value), None, eval_env)
        
        
    #检测特殊字符
    def check_value_special_str(self,value): 
        if re.findall("，", value) or re.findall("，", value):
            AlertView.Window(self.sheet_name+"工作表有中文或全角逗号{，}\n"+value).run() #弹出提示框
            raise
        if re.findall("＂", value):
            AlertView.Window(self.sheet_name+"工作表有全角号{＂}\n"+value).run() #弹出提示框
            raise
        if re.findall("“",value) or re.findall("”",value):
            AlertView.Window(self.sheet_name+"工作表有中文引号{“”}\n"+value).run() #弹出提示框
            raise 
    
    def get_constType(self):
        return self.const_types
    
    
