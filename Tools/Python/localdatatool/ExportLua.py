import os
import json
from localdatatool import LoadConfig, ExportLuaType
import collections
from tornado import template
import re

class ExportluaClass:
    def __init__(self,currPath=''):
        self.currPath = currPath
        self.root_list_task = {}  #temp文件夹里面所有数据
        self.export_lua_list = {} #那些表需要导出lua的数据
        self.struct_list = collections.OrderedDict()
        self.custom_lua_types = ExportLuaType.ExportType().get_custom_lua_types() #获取自定义数据类型
    
    def init_data(self):
        config=LoadConfig.LoadConfig()
        config.run()
        self.export_lua_list = config.get_export_lua_list()
        self.root_list_task = config.get_root_list_task()
        os.chdir(os.getcwd())
        with open(os.path.join("record", "types_recorder"), encoding="utf-8") as f:
            self.types_recorder = json.load(f)

    #检测配置文件中是否存在多余配置    
    def chek_config(self):
        for sheet_name,ignore_list in self.export_lua_list.items():  #{'VipConfig': []}
            if self.root_list_task.get(sheet_name) != None:
                self.struct_list[sheet_name] = [collections.OrderedDict(sorted(_ for _ in i.items() if _[0] not in ignore_list))
                                            for i in self.root_list_task[sheet_name]]
            else:
                print("想要导出lua的表:", sheet_name, "不存在 已忽略") 
    
            for k in ignore_list: #删除不需要导出的类型
                    self.types_recorder[sheet_name].pop(k)
        #删除一些多余的数据
        for struct in set(self.types_recorder) - set(self.struct_list):
            self.types_recorder.pop(struct)
    
    #输出lua--config所有文件
    def output_lua_config(self):
        os.chdir(self.currPath) #切换目录
        temName = "LuaConfig.txt"
        path = os.path.join("{}\\{}".format(self.currPath,"template"), temName + ".template")
        with open(path, encoding="utf-8") as f:
            t = template.Template(f.read())
        for sheet_name in self.export_lua_list:
            name = "{}{}".format(sheet_name,'.lua')
            if self.root_list_task.get(sheet_name) != None:
                s = t.generate(
                struct_list = self.struct_list,
                define = self.define,
                ).decode()
                s = re.sub(r"\s+\n", "\n", s)
            with open(os.path.join("output\\lua", name), "w", encoding="utf-8") as f:
                f.write(s)
                
            
          

    def define(self,k1, k2, v):
#         if not self.types_recorder[k1][k2] in self.xml_types_recorder:
#             t = self.custom_lua_types[self.types_recorder[k1][k2]](v)
#         else :
#             t = self.lua_xml_types_definitions(self.types_recorder[k1][k2])(v)
        t = self.custom_lua_types[self.types_recorder[k1][k2]](v)
        return t
        

#         lua_name_fmt = "{}={}".format
#     def lua_xml_types_definitions(self,key):
#         global xml_types_recorder
#         types = xml_types_recorder[key]
#     
#         dict_flag = False
#         global xml_types_idx
#         if xml_types_idx.get(key):
#             dict_flag = True
#             dict_key = xml_types_idx[key]
#         
#         def _repr(v):
#             if dict_flag:
#                 units = ",".join([
#                     lua_kv_fmt(unit[dict_key],
#                         "{{{}}}".format(",".join([
#                             lua_name_fmt(k, self.custom_lua_types[types[k]](v) if not types[k] in xml_types_recorder else lua_xml_types_definitions(types[k])(v)) for k, v in sorted(unit.items())
#                         ]))
#                     ) for unit in v
#                 ]) if v else ""
#             else:
#                 units = ",".join([
#                     "{{{}}}".format(",".join([
#                         lua_name_fmt(k, self.custom_lua_types[types[k]](v) if not types[k] in xml_types_recorder else lua_xml_types_definitions(types[k])(v)) for k, v in sorted(unit.items())
#                     ])) for unit in v
#                 ]) if v else ""
#             return "{{{}}}".format(units)
#         return _repr

    def run(self):
        self.init_data()
        self.chek_config()
        self.output_lua_config()
        print("ExportLua-->导出完成")



if __name__ == '__main__':
    print("ExportLua-->开始导出")
    currPath = os.getcwd() #当前路径
    export = ExportluaClass(currPath)
    export.run()
    