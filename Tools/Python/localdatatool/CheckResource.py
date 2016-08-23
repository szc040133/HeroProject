#检测资源类
import collections
import os
from utils import ConfigPath
import functools
import json
import Window

class ListDefaultDict(collections.OrderedDict):
    def __missing__(self, k):
        self[k] = []
        return self[k]

output_log_tasks= collections.defaultdict(dict)
dump_sorted = functools.partial(json.dumps, ensure_ascii=False, separators = (",", ": "),sort_keys=True, indent=4)          
class CheckRes:
    
    def __init__(self,callBack):
        self.callBackfun=callBack
        self.check_file_tasks={}
        self.uniq_tasks = ListDefaultDict()
        self.sort_tasks = ListDefaultDict()
        config = ConfigPath.Config(os.path.dirname(Window.__file__))
        self.resPath = config.get_ResPath()
        self.out_put_List = []
        
    #设置检测的唯一文件数据 
    def set_uniq_tasks(self,uniq_tasks=ListDefaultDict()):
        self.uniq_tasks = uniq_tasks
    
    #设置排序文件数据
    def set_sort_tasks(self,sort_tasks=ListDefaultDict()):
        self.sort_tasks = sort_tasks
    
    #设置检测资源文件是否存在的的数据
    def set_check_file(self,check_file_tasks={}):
        self.check_file_tasks = check_file_tasks
    
    #检测唯一数据字段
    def check_unig_task(self):
        for key, value in self.uniq_tasks.items():
            #VipConfig.xls -> VipConfig -> C [40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50]
            if len(frozenset(value)) != len(value):
                repeat_list = []
                for i in value:
                    if value.count(i) != 1 and i not in repeat_list:
                        repeat_list.append(i)
                show_repeat = ""
                if repeat_list:
                    show_repeat = "--> " + ", ".join(str(i) for i in repeat_list)
                #{'VipConfig.xls -> VipConfig -> C': '数据唯一检查失败: --> 40, 44'}
                output_log_tasks["unig"][key] = "该列重复数据: "+show_repeat
    
    #检测排除
    def check_sort_task(self):
        for key,list_value in self.sort_tasks.items():
            if sorted(list_value) != list(list_value):
                output_log_tasks["sort"][key] = "该列数据排序有错: "+str(list_value)
            
            
    
    #检测资源文件         
    def check_file_task(self):
        for cell, f in self.check_file_tasks.items():
            #cell---VipConfig.xls -> VipConfig -> D6    f---Sound\BGM\game-over\game-losed.mp3
            path_name = os.path.join(self.resPath, f)
            dir_name = os.path.dirname(path_name) #获取文件路径中所在的目录
            file_name = os.path.basename(path_name) #获取文件名
            if path_name != '' and os.listdir(dir_name).count(file_name) == 0:
                output_log_tasks["check_file"][cell] = "配置的资源文件或者文件夹不存在: "+"{}".format(path_name)
        
                
    def save_log(self):
        path = "{}{}".format(os.getcwd(), "\\tempfile")
        with open(os.path.join(path,"log.txt"), "w", encoding="utf-8") as f:
            f.write(dump_sorted(output_log_tasks))
    
    def check(self):
        if self.uniq_tasks:
            self.check_unig_task() #检测唯一
        
        if self.sort_tasks:
            self.check_sort_task() #排序
            
        if len(self.check_file_tasks)>0: #检测资源
            self.check_file_task()
    
        if len(output_log_tasks)>0: #保存log
            self.save_log()
                 
        if self.callBackfun:  #回调
            self.callBackfun()
        
        
