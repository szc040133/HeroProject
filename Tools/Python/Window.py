import tkinter as tk
import sys,os
from tkinter.ttk import Frame
from utils import ConfigPath, AlertView
import shutil
import LocalDataTool
import ProtobufTool
currPath=''
index_list=[]
pro_index_list = []
class Window:
    def __init__(self, title='导表编辑器', width=400, height=250, func1=bool, func2=bool,func3=bool,func5=bool,func6=bool,func7=bool):
        self.w = width
        self.h = height
        self.operation = 0;
        self.operationFunc1 = func1
        self.operationFunc2 = func2
        self.operationFunc3 = func3
        self.operationFunc5 = func5
        self.operationFunc6 = func6
        self.operationFunc7 = func7
        self.staIco = os.path.join(sys.exec_prefix, 'DLLs\py.ico') #可以设置图标
        self.root = tk.Tk(className=title)
        self.root.iconbitmap(self.staIco)
   
    def center(self):  #设置窗口自动屏幕居中
        ws = self.root.winfo_screenwidth()
        hs = self.root.winfo_screenheight()
        x = int( (ws/2) - (self.w/2) )
        y = int( (hs/2) - (self.h/2) )
        self.root.geometry('{}x{}+{}+{}'.format(self.w, self.h, x, y)) # 500x500是大小 +500+420是坐标

    def packBtn(self): #创建按钮
        frm = Frame(self.root)
        self.btn1=tk.Button(frm, text='一键导表',command=self.operationFunc1, width=15, height=2)
        self.btn1.pack(padx=20)
        self.btn2=tk.Button(frm, text='一键拷贝', command=self.operationFunc2, width=15, height=2)
        self.btn2.pack(padx=20,pady=30)
        self.btn3=tk.Button(frm, text='一键导表+拷贝', command=self.operationFunc3, width=15, height=2)
        self.btn3.pack(padx=20)
        frm.pack(side='left')
        
        frm1 = Frame(self.root)
        self.btn5=tk.Button(frm1,text='一键导协议',command=self.operationFunc5, width=15, height=2)
        self.btn5.pack(padx=20)
        self.btn6=tk.Button(frm1,text='一键拷贝',command=self.operationFunc6, width=15, height=2)
        self.btn6.pack(padx=20,pady=30)
        self.btn7=tk.Button(frm1,text='一键导协议+拷贝',command=self.operationFunc7, width=15, height=2)
        self.btn7.pack(padx=20)
        frm1.pack(side='right')
        
        frm2 = Frame(self.root)#bitmap='hourglass'
        self.labe=tk.Label(frm2,text='欢\n迎\n使\n用\n^_^',anchor = 'n')
        self.labe.pack(padx=30)
        frm2.pack(side='right')
       
    def loop(self):
        self.root.resizable(False, False)   #禁止修改窗口大小
        self.center()                       #窗口居中
        self.packBtn()
        self.root.mainloop()

def delete_log():
    filename = r'{}{}'.format(os.getcwd(),"\\localdatatool\\tempfile\\log.txt")
    if os.path.exists(filename):
        os.remove(filename)

def open_log():
    filename = r'{}{}'.format(os.getcwd(),"\\localdatatool\\tempfile\\log.txt")
    if os.path.exists(filename):
        cmd =  "{} {}".format("start",filename)
        os.system(cmd)  

global excelcopy_path
def get_path(name=""):
    config_path=ConfigPath.Config(currPath) #设置地址
    path = ''
    if name == "CS_GameConfig_CopyPath":
        path=config_path.get_CS_GameConfig_CopyPath()
    if name == "CS_LuaConfig_CopyPath":
        path = config_path.get_CS_LuaConfig_CopyPath()
    if name == "SC_GameConfig_CopyPath":
        path = config_path.get_SC_GameConfig_CopyPath()
    if name == "ProtoExportPath":
        path = config_path.get_ProtoExportPath()
    if name == "CS_ProtoBufLua_CopyPath":
        path = config_path.get_CS_ProtoBufLua_CopyPath()
    if name == "SC_ProtoBufConfig_CopyPath":
        path = config_path.get_SC_ProtoBufConfig_CopyPath()
    return path

#切换目录
def change_chdir(index):
    if index == 1:
        path = "{}\\{}".format(os.getcwd(),"localdatatool")
        os.chdir(path)
    elif index == 2:
        path = "{}\\{}".format(os.getcwd(),"protobuftool")
        os.chdir(path)

def func1():  #一键倒表
    print('开始导表')
    index_list.clear()
    index_list.append(1)
    change_chdir(1)
    LocalDataTool.run(currPath)
    return True

def func2(): #一键拷贝
    print('开始拷贝')
    if len(index_list) == 0:
        AlertView.Window('请先导表').run() #弹出提示框
        return
    cs_path=get_path("CS_GameConfig_CopyPath") #获取需要拷贝文件的目标地址
    if cs_path!=None and cs_path!="":
        list_dir = "{}\\{}".format(os.getcwd(),"output\\C#")
        for f in os.listdir(list_dir):
            if f[-3:]=="dll":
                src=os.path.join(list_dir,f) #拷贝文件的源地址
                print("拷贝文件-->"+src)
                shutil.copyfile(src, os.path.join(cs_path, f))  #拷贝文件
        
    cs_Lua_path=get_path("CS_LuaConfig_CopyPath")
    if cs_Lua_path!=None and cs_Lua_path!="":
        list_dir = "{}\\{}".format(os.getcwd(),"output\\lua")
        for f in os.listdir(list_dir):
            if f[-3:]=="lua":
                src=os.path.join(list_dir,f) #拷贝文件的源地址
                print("拷贝文件-->"+src)
                shutil.copyfile(src, os.path.join(cs_Lua_path, f))  #拷贝文件
                
    
    sc_gameconfig_path=get_path("SC_GameConfig_CopyPath")
    if sc_gameconfig_path!=None and sc_gameconfig_path!="":
        list_dir = "{}\\{}".format(os.getcwd(),"output\\server")
        for f in os.listdir(list_dir):
            if f[-6:]=="config":
                src=os.path.join(list_dir,f) #拷贝文件的源地址
                print("拷贝文件-->"+src)
                shutil.copyfile(src, os.path.join(sc_gameconfig_path, f))  #拷贝文件
                
    os.chdir(currPath)
    open_log()
    exit()
    return True

def func3(): #一键倒表+拷贝
    os.chdir(currPath)
    func1()
    func2()
    return True

#--------------------------------------------协议-----------------
def func5(): #一键到协议
    print('一键导协议')
    pro_index_list.clear()
    pro_index_list.append(1)
    change_chdir(2)
    ProtobufTool.run(currPath)
#     os.system("python TranslateToCS.py")
#     os.system("python ProtoXls.py")
#     os.system("python ProtoConv.py")
    return True

def func6(): #一键拷贝
    print('拷贝文件')
    if len(pro_index_list) == 0:
        AlertView.Window('请先导协议').run() #弹出提示框
        return
    protoExportPath=get_path("ProtoExportPath")
    if protoExportPath!=None and protoExportPath!="":
        list_dir = "{}\\{}".format(os.getcwd(),"output")
        for f in os.listdir(list_dir):
            if f[-3:]==".cs":
                src=os.path.join(list_dir,f) #拷贝文件的源地址
                print("拷贝文件-->"+src)
                shutil.copyfile(src, os.path.join(protoExportPath, f))  #拷贝文件
    
    cs_protoubuf_path=get_path("CS_ProtoBufLua_CopyPath")
    if cs_protoubuf_path!=None and cs_protoubuf_path!="":
        list_dir = "{}\\{}".format(os.getcwd(),"output")
        for f in os.listdir(list_dir):
            if f[-3:]=="txt":
                src=os.path.join(list_dir,f) #拷贝文件的源地址
                print("拷贝文件-->"+src)
                shutil.copyfile(src, os.path.join(cs_protoubuf_path, f))  #拷贝文件
                
    sc_protoubuf_path=get_path("SC_ProtoBufConfig_CopyPath")
    if sc_protoubuf_path!=None and sc_protoubuf_path!="":
        list_dir = "{}\\{}".format(os.getcwd(),"output")
        for f in os.listdir(list_dir):
            if f[-3:]=="erl":
                src=os.path.join(list_dir,f) #拷贝文件的源地址
                print("拷贝文件-->"+src)
                shutil.copyfile(src, os.path.join(sc_protoubuf_path, f))  #拷贝文件
    os.chdir(currPath)
    open_log()
    exit()
    return True

def func7(): #拷贝文件
    print('开始-导协议+拷贝')
    os.chdir(currPath)
    func5()
    func6()
    return True

if __name__ == '__main__':
    currPath = os.getcwd()
    os.chdir(currPath)
    delete_log()
    get_path()
    w = Window(func1=func1,func2=func2,func3=func3,func5=func5,func6=func6,func7=func7)
    w.loop()
    
    