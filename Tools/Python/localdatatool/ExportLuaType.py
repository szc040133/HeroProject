import json
def lua_repr_simple_type(v):
    return json.dumps(v, ensure_ascii = False)
lua_repr_int = lua_repr_float = lua_repr_str = lua_repr_bool = lua_repr_simple_type
lua_kv_fmt = "[{}]={}".format
class ExportType:
    
    def __init__(self):
        self.custom_lua_types = { #自定义lua类型
        "int": lua_repr_int,
        "int32": lua_repr_int,
        "float": lua_repr_float,
        "str": lua_repr_str,
        "bool": lua_repr_bool,
        "list_int": self.lua_repr_list_int,
        "list_float": self.lua_repr_list_float,
        "list_str": self.lua_repr_list_str,
        "dict_str_str": self.lua_repr_dict_str_str,
        
#         "list_int2": self.lua_repr_list_int2,
#         "list_int3": self.lua_repr_list_int3,
#         "list_float2": self.lua_repr_list_float2,
#         "list_float3": self.lua_repr_list_float3,
#         "list_str2": self.lua_repr_list_str2,
#         "list_str3": self.lua_repr_list_str3,
#         "dict_str_int": self.lua_repr_dict_str_int,
#         "dict_str_float": self.lua_repr_dict_str_float,
#         "dict_int_int": self.lua_repr_dict_int_int,
#         "dict_int_float": self.lua_repr_dict_int_float,
#         "dict_int_str": self.lua_repr_dict_int_str,
#         "dict_int_list_int": self.lua_repr_dict_int_list_int,
#         "dict_str_list_int": self.lua_repr_dict_str_list_int,
        }
        
    #获取自定义类型
    def get_custom_lua_types(self):
        return self.custom_lua_types
        
    def lua_repr_list_int(self,value):
        lst = ",".join(lua_repr_int(i) for i in value)
        return "{" + lst + "}"
    
    def lua_repr_list_float(self,value):
        lst = ",".join(lua_repr_float(i) for i in value)
        return "{" + lst + "}"
    
    def lua_repr_list_str(self,value):
        lst = ",".join(lua_repr_str(i) for i in value)
        return "{" + lst + "}"
    
    def lua_repr_dict_str_str(self,value):
        kvs = ",".join(lua_kv_fmt(lua_repr_str(k), lua_repr_str(v)) for k, v in sorted(value.items()))
        return "{" + kvs + "}"
    
#--------------------------------------以下类型暂时还没有用到---------------------------------------------------------
    
#     def lua_repr_list_int2(self,v):
#         lst = ",".join(self.lua_repr_list_int(i) for i in v)
#         return "{" + lst + "}"
#     
#     def lua_repr_list_int3(self,v):
#         lst = ",".join(self.lua_repr_list_int2(i) for i in v)
#         return "{" + lst + "}"
#     
#     def lua_repr_list_float2(self,v):
#         lst = ",".join(self.lua_repr_list_float(i) for i in v)
#         return "{" + lst + "}"
#     
#     def lua_repr_list_float3(self,v):
#         lst = ",".join(self.lua_repr_list_float2(i) for i in v)
#         return "{" + lst + "}"
# 
#     def lua_repr_list_str2(self,v):
#         lst = ",".join(self.lua_repr_list_str(i) for i in v)
#         return "{" + lst + "}"
#     
#     def lua_repr_list_str3(self,v):
#         lst = ",".join(self.lua_repr_list_str2(i) for i in v)
#         return "{" + lst + "}"
#     
#     def lua_repr_dict_str_int(self,value):
#         kvs = ",".join(lua_kv_fmt(lua_repr_str(k), lua_repr_int(v)) for k, v in sorted(value.items()))
#         return "{" + kvs + "}"
#     
#     def lua_repr_dict_str_float(self,value):
#         kvs = ",".join(lua_kv_fmt(lua_repr_str(k), lua_repr_float(v)) for k, v in sorted(value.items()))
#         return "{" + kvs + "}"
#     
#     def lua_repr_dict_int_str(self,value):
#         kvs = ",".join(lua_kv_fmt(lua_repr_int(k), lua_repr_str(v)) for k, v in sorted(value.items()))
#         return "{" + kvs + "}"
#     
#     def _lua_repr_dict_int_int(self,value):
#         kvs = ",".join(lua_kv_fmt(lua_repr_int(k), lua_repr_int(v)) for k, v in sorted(value.items()))
#         return "{" + kvs + "}"
#     
#     def lua_repr_dict_int_float(self,value):
#         kvs = ",".join(lua_kv_fmt(lua_repr_int(k), lua_repr_float(v)) for k, v in sorted(value.items()))
#         return "{" + kvs + "}"
#     
#     def lua_repr_dict_str_list_int(self,value):
#         kvs = ",".join(lua_kv_fmt(lua_repr_str(k), self.lua_repr_list_int(v)) for k, v in sorted(value.items()))
#         return "{" + kvs + "}"
#     
#     def lua_repr_dict_int_list_int(self,value):
#         kvs = ",".join(lua_kv_fmt(lua_repr_int(k), self.lua_repr_list_int(v)) for k, v in sorted(value.items()))
#         return "{" + kvs + "}"
        
        
        
        