#cs代码生成dll类 
import os

class CSDLL:
    def __init__(self,os_path):
        self.os_path = os_path
       
    def start(self):
        path = "{}{}".format(self.os_path,"\\output\\C#")
        os.chdir(path) #切换目录
        os.system("..\..\cscomplier\csc3.5.exe /target:library GameConfig.cs")
        os.chdir("../../") #回到初始目录
    
    def run(self):
        self.start()