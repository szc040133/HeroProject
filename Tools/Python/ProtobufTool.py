from protobuftool import TranslateToCS
from protobuftool import ProtoXls
from protobuftool import ProtoConv
from utils import ConfigPath
import os
import time

def run(path=''):
    #ranslateToCS.py
    config = ConfigPath.Config(path)
    ProtoPath = config.get_ProtoPath()
    ProtoExportPath = config.get_ProtoExportPath()
    #执行函数
    t = TranslateToCS.TranslateClass(ProtoPath,ProtoExportPath)
    t.runHandle()
    
    #ProtoXls.py
    time.sleep(2)
    config = ConfigPath.Config(path)
    TotalPath = config.get_TotalPath()
    path1 = "{}\\{}".format(path,"protobuftool")
    os.chdir(path1)
    currPath= os.getcwd()
    xlsPath = config.get_ProXlsPath()
    os.chdir(TotalPath) #切换目录
    xls = ProtoXls.ProtoXLS(currPath,xlsPath)
    xls.run()
    
    #ProtoConv.py
    config = ConfigPath.Config(path)
    TotalPath = config.get_TotalPath()
    os.chdir(TotalPath) #切换目录
    protoClass = ProtoConv.ProtoCombin(currPath,TotalPath)
    protoClass.run()
    