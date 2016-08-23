import json
import os
import collections
import glob
from tornado import template
import re
from tornado.util import ObjectDict
from utils import ConfigPath

class ProtoCombin:
   
    def __init__(self,currPath='',workPath=''):
        self.currPath = currPath
        self.workPath = workPath
        self.root = collections.OrderedDict()
        self.root_list = collections.OrderedDict()
        self.terms = {}
        self.protoFilelist = {}
        self.protoFileName = []
        self.server_root = ObjectDict()
        
    def init_data(self):
        typePath = os.path.join(self.currPath,"tempfile\\types_recorder")
        with open(typePath) as f:
            types_recorder = json.load(f)
        
        for key in types_recorder:
            self.terms[key] = {}  #{'protobuffs': {}}
            
        for term, ignore in sorted(self.terms.items()):
            path = '{}\\tempfile\\{}'.format(self.currPath,term)
            with open(path, encoding="utf-8") as f:
                self.root[term] = [collections.OrderedDict(sorted(_ for _ in i.items() if _[0] not in ignore))for i in json.load(f)]
                #root["protobuffs"]里面是所有协议数据
       
                
    def get_file_name(self):
        path="{}/proto/*.proto".format(self.workPath)
        for i in sorted(glob.glob(path)):
            k = os.path.basename(i).replace(".proto","")
            with open(i, encoding="utf-8") as f:
                self.protoFilelist[k] = f.read()
                
        protoFileName1=[]
        for k in self.protoFilelist:
            valueStr = self.protoFilelist[k]
            if valueStr.find("unit.proto")>0:
                self.protoFileName.append(k)
            else:
                protoFileName1.append(k)
        self.protoFileName = protoFileName1+self.protoFileName   
    
    def write_client_file(self,name):
        print("导出文件--->"+name)
        path = '{}\\template\\{}'.format(self.currPath, name+".template")
        with open(path, encoding="utf-8") as f:
            t = template.Template(f.read())
        s = t.generate(
            root=self.root, root_list=self.root_list,protoFileName = self.protoFileName).decode()
        s = re.sub(r"\s+\n", "\n", s)
        with open("{}/{}/{}".format(self.currPath,"output",name), "w", encoding="utf-8") as f:
            f.write(s)
            
    def export_client_file(self):
        self.write_client_file("ProtoSerializer.cs")
        self.write_client_file("NetworkInfos.txt")
        

    def read_protobuffs(self):
        for key in self.terms:
            path = '{}\\tempfile\\{}'.format(self.currPath,key)
            with open(path, encoding="utf-8") as f:
                self.server_root[key] = [ObjectDict(_) for _ in json.load(f)]
            
    def b_repr_sub1(self,v):
        if isinstance(v, list) and len(v) == 5:
            return v[:2]
        else:
            return v

    def b_repr_sub2(self,v):
        return "{{{}}}".format(",".join(map(str, v)))

    def b_repr_sub3(self,v):
        return "{{{}, {}}}".format(self.b_repr_sub2(v[0]), v[1])

    def b_repr(self,v):
        if isinstance(v, dict):
            return "[{}]".format(
                ", ".join("{{{},{}}}".format(
                    k, self.b_repr_sub1(v)) for k, v in sorted(v.items())))
        elif isinstance(v, list) and v and isinstance(v[0], str) \
                and v[0].startswith("random_"):
            return "{{ {}, [{}], [{}] }}".format(
                v[0],
                ", ".join(map(self.b_repr_sub2, v[1])),
                ", ".join(map(str, v[2])))
        elif isinstance(v, list) and all(map(lambda _: isinstance(_, str), v)):
            return  "[{}]".format(", ".join(map(str, v)))
        elif isinstance(v, list) and v and isinstance(v[0], str) and all(isinstance(i, int) for i in v[1:]):
            return  "[{{ {} }}]".format(", ".join(map(str, v)))

        return json.dumps(v, ensure_ascii=False) 
    
    def export_b_config(self,name):
        print("导出文件--->"+name)
        path = '{}\\template\\{}'.format(self.currPath, name+".template")
        with open(path, encoding="utf-8") as f:
            t = template.Template(f.read())
        s = t.generate(root=self.server_root, repr=self.b_repr).decode()
        s = re.sub(r"\s+\n", "\n", s)
        with open("{}/{}/{}".format(self.currPath,"output",name), "w", encoding="utf-8") as f:
            f.write(s)
            
    def export_server_config(self):
        self.export_b_config("message_code.erl")

    def run(self):
        self.init_data()
        self.get_file_name()
        self.export_client_file()
        self.read_protobuffs()
        self.export_server_config()
        

if __name__ == "__main__":
    currPath = os.getcwd()
    config = ConfigPath.Config('E:\Wrok\Python')
    TotalPath = config.get_TotalPath()
    os.chdir(TotalPath) #切换目录
    protoClass = ProtoCombin(currPath,TotalPath)
    protoClass.run()