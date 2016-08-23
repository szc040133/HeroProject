#输出C#类
from localdatatool import LoadConfig, ExportCSType
import os
import json
import collections
import time
from tornado import template
import re

class Default(dict):
        def __missing__(self, key):
            return key
        
class OutPutCS:
    def __init__(self,currPath=''):
        self.currPath = currPath
        self.root_list_task = {}  #temp文件夹里面所有数据
        self.export_sheet_list = {} #需要导出的表的数据
        self.struct_list = collections.OrderedDict()
        self.custom_cs_types = ExportCSType.ExportType().get_custom_cs_types() #获取自定义数据类型
        self.base_cs_types = ExportCSType.ExportType().get_base_cs_types() #获取基础数据类型
        self.idx_key_map ={}
        
    
    
    #初始化配置数据
    def init_data(self):
        config=LoadConfig.LoadConfig()
        config.run()
        self.export_sheet_list = config.get_export_sheet_list()
        self.root_list_task = config.get_root_list_task()
        os.chdir(os.getcwd())
        with open(os.path.join("record", "types_recorder"), encoding="utf-8") as f:
            self.types_recorder = json.load(f)
        
    #检测配置文件中是否存在多余配置    
    def chek_config(self):
        for sheet_name,ignore_list in self.export_sheet_list.items():  #{'VipConfig': []}
            if self.root_list_task.get(sheet_name) != None:
                self.struct_list[sheet_name] = [collections.OrderedDict(sorted(_ for _ in i.items() if _[0] not in ignore_list))
                                            for i in self.root_list_task[sheet_name]]
            else:
                print("想要导出的表:", sheet_name, "不存在 已忽略") 
    
            for k in ignore_list: #删除不需要导出的类型
                    self.types_recorder[sheet_name].pop(k)
        #删除一些多余的数据
        for struct in set(self.types_recorder) - set(self.struct_list):
            self.types_recorder.pop(struct)
    
    def output_game_config(self):
        os.chdir(self.currPath) #切换目录
        name = "GameConfig.cs" 
        path = os.path.join("{}\\{}".format(self.currPath,"template"), name + ".template")
        with open(path, encoding="utf-8") as f:
            t = template.Template(f.read())
        
        s = t.generate(
            struct_list = self.struct_list,
            types = self.types_recorder,
            declare = self.declare,
            define = self.define,
        ).decode()
        s = re.sub(r"\s+\n", "\n", s)
       
        with open(os.path.join("output\\C#", name), "w", encoding="utf-8") as f:
            f.write(s)
            
    def declare(self,k):
#         if not k in self.xml_types_recorder:
#             t = self.base_cs_types[k]
#         else:
#             t = self.cs_xml_types_declarations(k)
        t = self.base_cs_types[k]
        return t
    
    def define(self,k1,k2,v):
#         if not self.types_recorder[k1][k2] in xml_types_recorder:
#             t = self.custom_cs_types[self.types_recorder[k1][k2]](v)
#         else :
#             t =self.cs_xml_types_definitions(self.types_recorder[k1][k2])(v)
        t = self.custom_cs_types[self.types_recorder[k1][k2]](v)
        return t
        
    def cs_xml_types_declarations(self,key):
        if key.startswith("list_"):
            return key[len("list_"):] + "[]"
        elif key.startswith("dict_"):
            l = key[len("dict_"):].split("_", 1)
            return "Dictionary<" + l[0] + ", " + l[1] + ">"
    
   
    
    def run(self):
        self.init_data()
        time.sleep(0.1)
        self.chek_config()
        self.output_game_config()
        print("ExportCS-->导出完成")


if __name__ == '__main__':
    print("ExportCS-->开始导出")
    currPath = os.getcwd() #当前路径
    export = OutPutCS(currPath)
    export.run()
    

