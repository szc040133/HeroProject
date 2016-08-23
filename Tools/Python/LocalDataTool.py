from localdatatool import Localxls
from localdatatool import ExportCS
from localdatatool import CscompileDll
from localdatatool import ExportLua
from localdatatool import ExportServer
from utils import ConfigPath
import os

def run(path=''):
    #Localxls.py
    config = ConfigPath.Config(path)
    xls = Localxls.paresxls(config.get_CS_Excel_path())
    xls.run()
    
    #ExportCS.py
    currPath = os.getcwd() #当前路径 E:\Wrok\Python\localdatatool 要调试直接进去某个类写死
    export = ExportCS.OutPutCS(currPath)
    export.run()
    
    #CscompileDll.py
    cs_dll = CscompileDll.CSDLL(currPath)
    cs_dll.run()
    
    #ExportLua.py
    expLua = ExportLua.ExportluaClass(currPath)
    expLua.run()
    
    #ExportServer.py
    expserver = ExportServer.ExportServerClass(currPath)
    expserver.run()
    
    

    