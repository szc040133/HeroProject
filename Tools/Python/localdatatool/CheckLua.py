import json
import os
import re
import functools
from utils import AlertView

lua_recorder = {}
dump_sorted = functools.partial(json.dumps, ensure_ascii=False, separators = (",", ": "),sort_keys=True, indent=4)
class tool:
    
    def __init__(self,json_outputs,lua_tasks):
        self.json_outputs = json_outputs
        self.lua_tasks = lua_tasks
        self.sounds = {i["id"]: i["path"] for i in json_outputs["sound"]}
        #self.log_tasks= collections.defaultdict(dict)
        
    #检测log文件是否存在，存在的先打开log
    def load_log(self):
        filename = r'{}{}'.format(os.getcwd(),"\\tempfile\\log.txt")
        if os.path.exists(filename):
            with open(filename, encoding="utf-8") as f:
                self.log_tasks = json.load(f)
        #设置key
        self.log_tasks["lua"] ={}  
    
    def check_lua_task(self):
        if len(self.lua_tasks)<=0:
            return
        sounds = self.sounds
        sound_id_lua_pattern = [
            r"Sound\s*\(\s*([\s\S]+?)\s*\)",
        ]
        self.error=True
        for sheet_name, lua_task in self.lua_tasks.items():
           
            for key, luas in lua_task.items():
                for lua in luas:
                    asset_lst = []
                    sound_ids = []
                    tag = lua[1] #VipConfig.xls -> VipConfig -> K3
                    if lua[0]: #Sound(10059)
                        ## 音效
                        sound_ids.extend(set(int(sound_id) if sound_id.isdigit() else sound_id
                                              for pattern in sound_id_lua_pattern
                                              for sound_id in set(re.findall(pattern, lua[0]))
                                              if sound_id != "0"                                            # 特殊允许
                                              ))

                        ## 可允许格式为"xxx,xxx"
                        tmp = [sound_id for sound_id in sound_ids if type(sound_id) == str]
                        for sound in tmp:
                            if sound.startswith('"'):
                                sound_id_list = sound.strip('"').split(',')
                                sound_ids.remove(sound)
                                sound_ids.extend(set(int(i) for i in sound_id_list if i not in sound_ids))
                        
                        error_ids = set(i for i in set(sound_ids) if i not in list(sounds.keys()))
                        
                        if error_ids:
                            self.error = False
                            self.log_tasks["lua"][tag] = "不存在的sound id: " + str(error_ids)
                        
                        
                        asset_lst.extend(set(sounds[i] for i in set(sound_ids) - error_ids if sounds[i] not in asset_lst))

                        asset_lst.extend(set(asset for asset in re.findall(r'AttribBuff\s*\(\s*\"\s*Mat\s*,\s*([\s\S]+?)\s*\"', lua[0]) if asset not in asset_lst))

                        for asset in asset_lst:
                            if asset.count('\\') > 0:
                                self.log_tasks["lua"][tag] = " 资源路径格式有误: " + asset
                                self.error = False

                        if not lua_recorder.get(sheet_name):
                            lua_recorder[sheet_name] = {}
                        if not lua_recorder[sheet_name].get(key):
                            lua_recorder[sheet_name][key] = {}
                        lua_recorder[sheet_name][key][lua[0]] = asset_lst
                        
        if self.error == True:
            path = "{}\\tempfile\\record".format(os.getcwd())
            with open(os.path.join(path, "lua_recorder"), "w", encoding="utf-8") as f:
                f.write(functools.partial(json.dumps, ensure_ascii=False,
                                    separators = (",", ": "),
                                    sort_keys=True, indent=4)(lua_recorder))
        else:
            self.save_log()
            msg = "检测到lua配置有错，请查看log文件"
            AlertView.Window(msg,True).run() #弹出提示框
    
    def save_log(self):
        path = "{}{}".format(os.getcwd(), "\\tempfile")
        with open(os.path.join(path,"log.txt"), "w", encoding="utf-8") as f:
            f.write(dump_sorted(self.log_tasks))
        
    def check(self):
        self.load_log()
        self.check_lua_task()
        
        
