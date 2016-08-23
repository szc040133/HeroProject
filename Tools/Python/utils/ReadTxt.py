#读取路径txt类
class ReadTxt:
    def __init__(self,path=""):
        self.path = path
        
    global pathlist
    pathlist = {}
    def setTxt(self): #读取txt内容
        with open(self.path, "r") as f:
                data = str(f.read())
                dataList = data.split('\n')
                for valueStr in dataList:
                    if(valueStr.find("=")>0):
                        valueList = valueStr.split("=")
                        key = str(valueList[0]).strip()
                        value = valueList[len(valueList)-1].strip()
                        pathlist[key] = value
                        
    #格式如下{'packPath ': ' "E:\\Wrok\\Client"', 'workPath ': ' "E:\\Wrok\\Client"'}
    def getTxt(self):
        self.setTxt()
        return pathlist