#工具配置地址类
from utils import ReadTxt
import os
global path_list
path_list = {}
                 
class Config:
    def __init__(self,path=''):
        if path!="":
            self.txt =ReadTxt.ReadTxt(os.path.join(path, "address.txt"))
            path_list = self.txt.getTxt()
            self.ResPath = path_list["ResPath"].strip("\"")
            self.CS_GameConfig_CopyPath = path_list["CS_GameConfig_CopyPath"].strip("\"")
            self.CS_LuaConfig_CopyPath = path_list["CS_LuaConfig_CopyPath"].strip("\"")
            self.SC_GameConfig_CopyPath = path_list["SC_GameConfig_CopyPath"].strip("\"")
            self.CS_Excel_path = path_list["CS_Excel_path"].strip("\"")
    
            #------------------------协议地址-------------------------------
            self.TotalPath = path_list["TotalPath"].strip("\"")
            self.ProtoPath = path_list["ProtoPath"].strip("\"")
            self.ProtoExportPath = path_list["ProtoExportPath"].strip("\"")
            self.ProXlsPath = path_list["ProXlsPath"].strip("\"")
            self.CS_ProtoBufLua_CopyPath = path_list["CS_ProtoBufLua_CopyPath"].strip("\"")
            self.SC_ProtoBufConfig_CopyPath = path_list["SC_ProtoBufConfig_CopyPath"].strip("\"")
            
    #--------------------------------以下是导表工具需要配置地址-----------------------------
    
    #项目资源地址  
    def get_ResPath(self):
        return self.ResPath
   
    #客户端gameConfig拷贝目标地址（填空表示不需要拷贝""）
    def get_CS_GameConfig_CopyPath(self):
        return self.CS_GameConfig_CopyPath
    
    #客户端lua拷贝目标地址（填空表示不需要拷贝""）
    def get_CS_LuaConfig_CopyPath(self):
        return self.CS_LuaConfig_CopyPath
    
    #服务端gameconfig拷贝目标地址（填空表示不需要拷贝""）
    def get_SC_GameConfig_CopyPath(self):
        return self.SC_GameConfig_CopyPath
    
    def get_CS_Excel_path(self):
        return self.CS_Excel_path
    
    
    #--------------------------------以下是Probuffs协议需要配置地址-----------------------------
    
    #协议目录总地址
    def get_TotalPath(self):
        return self.TotalPath
    
    #ptotobuf目录地址(里面都是.proto文件后端上传的文件)
    def get_ProtoPath(self):
        return self.ProtoPath
    
    #protobuf导出地址
    def get_ProtoExportPath(self):
        return self.ProtoExportPath
    
    #Proxls协议表地址
    def get_ProXlsPath(self):
        return self.ProXlsPath
    
    #客户端lua导出地址----（填空表示不拷贝
    def get_CS_ProtoBufLua_CopyPath(self):
        return self.CS_ProtoBufLua_CopyPath
    
    #服务端协议拷贝地址---（填空表示不拷贝）
    def get_SC_ProtoBufConfig_CopyPath(self):
        return self.SC_ProtoBufConfig_CopyPath
    
    