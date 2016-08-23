#解析导出配置文件类
import xml.etree.ElementTree as etree
import os
import glob
import json
import time

class Default(dict):
        def __missing__(self, key):
            return key
        
class LoadConfig:
    def __init__(self):
        self.root_list_task = {}  #tem文件里面的总数据
        path = "{}\\{}".format(os.getcwd(), "tempfile")
        os.chdir(path)

    #阅读配置文件
    def read_config_file(self):
        self.xml_root = etree.parse("config\\export.xml").getroot()
        xml_client = self.xml_root.find("for_client")
        _default = Default()
        self.export_sheet_list = {   #for example:{'VipConfig': []} --->ignore_lis忽视的列表该了表重的字段不会导出
          i.attrib["name"] : eval(i.attrib["ignore_list"], None, _default) for i in xml_client.find("for_struct_list").getchildren()
        }
        
    #解析lua导出的表数据
    def read_config_lua(self):
        eval_env = Default()
        xml_client = self.xml_root.find("for_lua")
        self.export_lua_list = {
        i.attrib["name"] : eval(i.attrib["ignore_list"], None, eval_env) for i in xml_client.find("for_struct_list").getchildren()
        }
      
    #解析服务端导出数据  
    def read_config_server(self):
        eval_env = Default()
        xml_server = self.xml_root.find("for_server")
        self.export_server_list = {
            i.attrib["name"] : {
                "output_name"   : i.attrib["output_name"],
                "pattern"       : i.attrib["pattern"],
                "extend_list"   : eval(i.attrib["extend_list"], None, eval_env),
                "params_list"   : eval(i.attrib["params_list"], None, eval_env),
            } for i in xml_server.find("for_struct_list").getchildren()
        }
        
    #表数据   
    def get_export_sheet_list(self):
        return self.export_sheet_list
    
    #lua数据
    def get_export_lua_list(self):
        return self.export_lua_list
    
    #服务端数据
    def get_export_server_list(self):
        return self.export_server_list
    
    #获取表总数据
    def load_temp_file(self):
        for i in sorted(glob.glob('tmp/*')):
            k = os.path.basename(i) #获取文件名
            with open(i, encoding="utf-8") as f:
                self.root_list_task[k] = json.load(f)
        
    def get_root_list_task(self):
        return self.root_list_task
    
    def run(self):
        print("LoadConfig-->开始解析配置文件")
        self.read_config_file()
        self.read_config_lua()
        self.read_config_server()
        time.sleep(0.1) 
        self.load_temp_file()
        print("LoadConfig-->解析配置 文件完成")


if __name__ == '__main__':
    output=LoadConfig()
    output.run()
    
    