#导出类型设置类
import json
cs_repr_int = str
cs_repr_str = cs_repr_bool = json.dumps
cs_repr_float = "{}f".format

kv_fmt = "{{{},{}}}".format
class ExportType:

    def __init__(self):
        self.custom_cs_types = { #自定义类型
        "int": cs_repr_int,
        "int32": cs_repr_int,
        "float": cs_repr_float,
        "str": cs_repr_str,
        "bool": cs_repr_bool,
        "list_int": self.cs_repr_list_int,
        "list_float": self.cs_repr_list_float,
        "list_str": self.cs_repr_list_str,
        "dict_str_str": self.cs_repr_dict_str_str,
        #"list_int2": self.cs_repr_list_int2,
        #"list_int3": self.cs_repr_list_int3,
        #"list_float2": self.cs_repr_list_float2,
        #"list_float3": self.cs_repr_list_float3,
        #"list_str2": self.cs_repr_list_str2,
        #"list_str3": self.cs_repr_list_str3,
        #"dict_str_int": self.cs_repr_dict_str_int,
        #"dict_str_float": self.cs_repr_dict_str_float,
        #"dict_int_int": self.cs_repr_dict_int_int,
        #"dict_int_float": self.cs_repr_dict_int_float,
        #"dict_int_str": self.cs_repr_dict_int_str,
        #"dict_int_list_int": self.cs_repr_dict_int_list_int,
        #"dict_str_list_int": self.cs_repr_dict_str_list_int,
       }  
        
        self.base_cs_types= {
        "int": "int",
        "int32": "int",
        "str": "string",
        "float": "float",
        "bool": "bool",
        "list_int": "int[]",
        "list_float": "float[]",
        "list_str": "string[]",
        "dict_str_str": "Dictionary<string, string>",
        
        #"list_int2": "int[][]",
        #"list_int3": "int[][][]",
        #"list_float2": "float[][]",
        #"list_float3": "float[][][]",
        #"list_str2": "string[][]",
        #"list_str3": "string[][][]",
        #"dict_str_int": "Dictionary<string, int>",
        #"dict_str_float": "Dictionary<string, float>",
        #"dict_int_int": "Dictionary<int, int>",
        #"dict_int_float": "Dictionary<int, float>",
        #"dict_int_str": "Dictionary<int, string>",
        #"dict_int_list_int": "Dictionary<int, int[]>",
        #"dict_str_list_int": "Dictionary<string, int[]>",
        }
        
    #获取自定义类型
    def get_custom_cs_types(self):
        return self.custom_cs_types
    
    #获取基础定义类型
    def get_base_cs_types(self):
        return self.base_cs_types
    
    def cs_repr_list_int(self,value):
        lst = ",".join(cs_repr_int(i) for i in value)
        return "new int[]{" + lst + "}"
    
    def cs_repr_list_float(self,value):
        lst = ",".join(cs_repr_float(i) for i in value)
        return "new float[]{" + lst + "}"

    def cs_repr_list_str(self,value):
        lst = ",".join(cs_repr_str(i) for i in value)
        return "new string[]{" + lst + "}"

    def cs_repr_dict_str_str(self,value):
        kvs = ",".join(kv_fmt(cs_repr_str(k), cs_repr_str(v)) for k, v in sorted(value.items()))
        return "new Dictionary<string, string>{" + kvs + "}"

#-------------------------------------华丽的分割线，以下暂时还没有用到-------------------------------------------------------------------------

    def cs_repr_list_int2(self,v):
        lst = ",".join(self._cs_repr_list_int(i) for i in v)
        return "new int[][]{" + lst + "}"

    def cs_repr_list_int3(self,v):
        lst = ",".join(self._cs_repr_list_int2(i) for i in v)
        return "new int[][][]{" + lst + "}"
    
    def cs_repr_list_float2(self,v):
        lst = ",".join(self._cs_repr_list_float(i) for i in v)
        return "new float[][]{" + lst + "}"

    def cs_repr_list_float3(self,v):
        lst = ",".join(self._cs_repr_list_float2(i) for i in v)
        return "new float[][][]{" + lst + "}"

    def cs_repr_list_str2(self,v):
        lst = ",".join(self._cs_repr_list_str(i) for i in v)
        return "new string[][]{" + lst + "}"

    def cs_repr_list_str3(self,v):
        lst = ",".join(self._cs_repr_list_str2(i) for i in v)
        return "new string[][][]{" + lst + "}"

    def cs_repr_dict_str_int(self,value):
        kvs = ",".join(kv_fmt(cs_repr_str(k), cs_repr_int(v)) for k, v in sorted(value.items()))
        return "new Dictionary<string, int>{" + kvs + "}"

    def cs_repr_dict_str_float(self,value):
        kvs = ",".join(kv_fmt(cs_repr_str(k), cs_repr_float(v)) for k, v in sorted(value.items()))
        return "new Dictionary<string, float>{" + kvs + "}"

    def cs_repr_dict_int_str(self,value):
        kvs = ",".join(kv_fmt(cs_repr_int(k), cs_repr_str(v)) for k, v in sorted(value.items()))
        return "new Dictionary<int, string>{" + kvs + "}"

    def cs_repr_dict_int_int(self,value):
        kvs = ",".join(kv_fmt(cs_repr_int(k), cs_repr_int(v)) for k, v in sorted(value.items()))
        return "new Dictionary<int, int>{" + kvs + "}"

    def cs_repr_dict_int_float(self,value):
        kvs = ",".join(kv_fmt(cs_repr_int(k), cs_repr_float(v)) for k, v in sorted(value.items()))
        return "new Dictionary<int, float>{" + kvs + "}"

    def cs_repr_dict_str_list_int(self,value):
        kvs = ",".join(kv_fmt(cs_repr_str(k), self._cs_repr_list_int(v)) for k, v in sorted(value.items()))
        return "new Dictionary<string, int[]>{" + kvs + "}"

    def cs_repr_dict_int_list_int(self,value):
        kvs = ",".join(kv_fmt(cs_repr_int(k), self._cs_repr_list_int(v)) for k, v in sorted(value.items()))
        return "new Dictionary<int, int[]>{" + kvs + "}"
