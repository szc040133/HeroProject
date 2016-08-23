import tkinter as tk
import sys,os
#弹出框类
class Window:  
    def __init__(self,content='有错误',boo=False,title='提示框', width=300, height=120):
        self.w = width
        self.h = height
        self.content = content
        self.isopen_log = boo
        self.staIco = os.path.join(sys.exec_prefix, 'DLLs\pyc.ico') #可以设置图标
        self.root = tk.Tk(className=title)
        self.root.iconbitmap(self.staIco)
   
    def center(self):  #设置窗口自动屏幕居中
        ws = self.root.winfo_screenwidth()
        hs = self.root.winfo_screenheight()
        x = int( (ws/2) - (self.w/2) )
        y = int( (hs/2) - (self.h/2) )
        self.root.geometry('{}x{}+{}+{}'.format(self.w, self.h, x, y)) # 500x500是大小 +500+420是坐标

    def createLabel(self): #创建标签
        self.label = tk.Label(self.root,width=70, height=5,compound='center')
        self.label['text'] = self.content
        self.label.pack()
       
    def createBtn(self): #创建按钮
        btnQuit = tk.Button(self.root, text='确定', command=self.event, width=10, height=1)
        btnQuit.pack(padx=20, side='bottom')
    
    def event(self):
        if self.isopen_log == True:
            filename = r'{}{}'.format(os.getcwd(),"\\tempfile\\log.txt")
            print(filename)
            if os.path.exists(filename):
                cmd =  "{} {}".format("start",filename)
                os.system(cmd)
            else:
                self.root.quit()
        else:
            self.root.quit()
        
        
    def run(self):
        self.root.resizable(False, False)   #禁止修改窗口大小
        self.center()                       #窗口居中
        self.createLabel()
        self.createBtn()
        self.root.mainloop()