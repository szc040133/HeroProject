import os
import shutil
from utils import ConfigPath
from utils import AlertView
import Window

class TranslateClass:
    def __init__(self,protoPath="",exportPath=""):
        self.protoPath = protoPath
        self.exportPath = exportPath
    
    def checekPath(self):# 检测路径是否存在
        probo = os.path.exists(self.protoPath)
        expbo = os.path.exists(self.exportPath) 
        if probo == False:
            win = AlertView.Window(self.protoPath+'路径不存在') #弹出提示框
            win.run()
            raise RuntimeError #停止代码执行
        if expbo == False:
            win = AlertView.Window(self.exportPath+'路径不存在') #弹出提示框
            win.run()
            raise RuntimeError #停止代码执行
         
    def startHandle(self): 
        os.chdir(self.protoPath) #切换目录
        for f in os.listdir(self.protoPath):
            if f[-6:] == ".proto" and os.path.isfile(os.path.join(self.protoPath,f)):
                file_name = f[0:-6]+".cs"
                cmd = "protogen -i:%s -o:%s" % (f, file_name) #调用C#代码生成工具，生成C#代码文件
                print(cmd)
                os.system(cmd)
                shutil.copyfile(file_name, os.path.join(self.exportPath, file_name))  #拷贝文件
                os.remove(file_name) #删除多余的文件
        
    def runHandle(self):
        self.checekPath()
        self.startHandle()

if __name__ == '__main__':
    #获取配置地址
    config = ConfigPath.Config(os.path.dirname(Window.__file__))
    ProtoPath = config.get_ProtoPath()
    ProtoExportPath = config.get_ProtoExportPath()
    #执行函数
    t = TranslateClass(ProtoPath,ProtoExportPath)
    t.runHandle()
    
    
    
    
    
    
    
