import os
import json
from localdatatool import LoadConfig, ExportServerType
from utils import AlertView
import collections
from tornado import template
import re

class ExportServerClass:
    
    def __init__(self,currPath=''):
        self.currPath = currPath
        self.root_list_task = {}  #temp文件夹里面所有数据
        self.export_server_list = {} #那些表需要导出 服务端的数据
        self.struct_list = collections.OrderedDict()
        self.custom_sc_types = ExportServerType.ExportServerType().get_custom_sc_types() #获取自定义数据类型
        
    def init_data(self):
        config=LoadConfig.LoadConfig()
        config.run()
        self.export_server_list = config.get_export_server_list()
        self.root_list_task = config.get_root_list_task()
        os.chdir(os.getcwd())
        with open(os.path.join("record", "types_recorder"), encoding="utf-8") as f:
            self.types_recorder = json.load(f)

    def chek_config(self):
        for sheet_name, value in self.export_server_list.items():
            if self.root_list_task.get(sheet_name) != None:
                self.struct_list[sheet_name] = [collections.OrderedDict(sorted(x for x in i.items() if x[0] in value["params_list"][0]))
                             for i in self.root_list_task[sheet_name]]
            else:
                print("想要导出lua的表:", sheet_name, "不存在 已忽略")
            
            match = [int(i) for i in re.findall("{([0-9]+)}", value["pattern"])]
            if not match or not value["params_list"] or [i for i in match if i < 0 or i >= len(value["params_list"])]:
                msg="服务端导出配置出错: for_server>>for_struct_list\n-->name: {{}}".format(sheet_name)
                AlertView.Window(msg).run() #弹出提示框
                raise RuntimeError
        
            if not sheet_name.startswith("__"):
                l = [ii for i in value["params_list"] for ii in i if ii not in value["extend_list"] and ii not in self.types_recorder[sheet_name]]
                if l:
                    msg = "服务端导出配置出错: for_server>>for_struct_list\n-->name:{{}}param_list: {{}}".format(sheet_name,l)
                    AlertView.Window(msg).run() #弹出提示框
                    raise RuntimeError
                
    def output_server_config(self):
        os.chdir(self.currPath) #切换目录
        name = "game.config"
        path = os.path.join("{}\\{}".format(self.currPath,"template"), name + ".template")
        with open(path, encoding="utf-8") as f:
            t = template.Template(f.read())
        s = t.generate(
            struct_list = self.struct_list,
            for_struct_list = self.export_server_list,
            define=lambda k1, k2, v: self.custom_sc_types[self.types_recorder[k1][k2]](v),
            ).decode()
        s = re.sub(r"\s+\n", "\n", s)
        with open(os.path.join("output\\server", name), "w", encoding="utf-8") as f:
            f.write(s)


    def run(self):
        self.init_data()
        self.chek_config()
        self.output_server_config()
        print("ExportServer-->导出完成")
    
        
if __name__ == '__main__':
    print("ExportServer-->开始导出")
    currPath = os.getcwd() #当前路径
    export = ExportServerClass(currPath)
    export.run()
    
    