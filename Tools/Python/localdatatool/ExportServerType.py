import json

def sc_repr_simple_type(v):
    if isinstance(v, str) and v.count("\\\n"):
        v = v.replace("\\\n", "")
    return json.dumps(v,ensure_ascii=False)

sc_repr_int = sc_repr_str = sc_repr_float = sc_repr_simple_type
kv_fmt = "{{{},{}}}".format
class ExportServerType:
    
    def __init__(self):
        self.custom_sc_types = { #自定义服务端类型
        "int": sc_repr_int,
        "int32": sc_repr_int,
        "float": sc_repr_float,
        "str": sc_repr_str,
        "string": sc_repr_str,
        "bool": self.sc_repr_bool,
        "list": self.sc_repr_list,
        "list_int": self.sc_repr_list_int,
        "list_float": self.sc_repr_list_float,
        "list_str": self.sc_repr_list_str,
        "dict_str_str": self.sc_repr_dict_str_str,
        
        
#         "list_dict": self.sc_repr_list_dict,
#         "list_int2": self.sc_repr_list_int2,
#         "list_int3": self.sc_repr_list_int3,
#         "list_float2": self.sc_repr_list_float2,
#         "list_float3": self.sc_repr_list_float3,
#         "list_str2": self.sc_repr_list_str2,
#         "list_str3": self.sc_repr_list_str3,
#         "dict_str_int": self.sc_repr_dict_str_int,
#         "dict_str_float": self.sc_repr_dict_str_float,
#         "dict_int_int": self.sc_repr_dict_int_int,
#         "dict_int_float": self.sc_repr_dict_int_float,
#         "dict_int_str": self.sc_repr_dict_int_str,
#         "dict_int_list_int": self.sc_repr_dict_int_list_int,
#         "dict_str_list_int": self.sc_repr_dict_str_list_int,
#         "mess": self.sc_repr_mess,
#         "mess_fixed": self.sc_repr_mess_fixed,
#         "BuffVO": self.sc_repr_BuffVO,
#         "condition": self.sc_repr_condition,
#         "datetime": self.sc_repr_datetime,
#         "dict_int_SceneDieLua": self.sc_repr_dict_int_SceneDieLua,
        }
    
    #获取自定义类型
    def get_custom_sc_types(self):
        return self.custom_sc_types
        
    def sc_repr_bool(self,v):
        if v != False:
            return "1"
        else:
            return "0"
        
    def sc_repr_list(self,v):###first element is a atom
        return  "[{{{}}}]".format(",".join(map(str, v)))
    
    
    def sc_repr_list_str(self,v):#list_atom
        lst = ",".join(str(_) for _ in v)
        return '"[' + lst + ']"'
    
    sc_repr_list_int = sc_repr_list_float = sc_repr_list_str
     
    
    def sc_repr_simple_dict(self,v):
        kvs = ",".join(kv_fmt(k, v) for k, v in sorted(v.items()))
        return "[" + kvs + "]"

    sc_repr_dict_str_int = sc_repr_dict_str_float = sc_repr_dict_str_str = sc_repr_dict_int_str = sc_repr_dict_int_int = sc_repr_dict_int_float = sc_repr_dict_str_list_int = sc_repr_dict_int_list_int = sc_repr_simple_dict




    def sc_repr_list_dict(self,raw):
        lst = ",".join("{{{},{}}}".format(k, v) for d in raw for k, v in sorted(d.items()))
        return "[" + lst + "]"
    
    def sc_repr_list_str2(self,v):#list_atom2
        lst = ",".join(self.sc_repr_list_str(_).strip('"') for _ in v)
        return '"[' + lst + ']"'
    
    sc_repr_list_int2 = sc_repr_list_float2 = sc_repr_list_str2
    
    def sc_repr_list_str3(self,v):#list_atom3
        lst = ",".join(self.sc_repr_list_str2(_).strip('"') for _ in v)
        return '"[' + lst + ']"'
    
    sc_repr_list_int3 = sc_repr_list_float3 = sc_repr_list_str3
    
    
    
    def sc_repr_mess(self,v):
        def fmt(k, n1, n2=None, n3=None, n4=None):
            if n2 is None:
                return '{{{},{}}}'.format(k, n1)
            elif n3 is None and n4 is None:
                return '{{{},{},{}}}'.format(k, n1, n2)
            else:
                return '{{{},{},{},{},{}}}'.format(k, n1, n2, n3, n4)
            return '{{{},[{}],{}}}'.format(
                v[0],
                ",".join(fmt(*i) for i in v[1]),
                v[2], 
                )

    def sc_repr_mess_fixed(self,v):
        def fmt(v):
            lst = ','.join(map(str, v))
            return '{'+lst+'}'
        return '[{}]'.format(','.join(fmt(k) for k in v))
    
    def sc_repr_BuffVO(self,buffs):
        fmt = "[{}, {}]".format
        kvs = ",".join(kv_fmt(k, fmt(*v)) for k, v in sorted(buffs.items()))
        return "[" + kvs + "]"
    
    def sc_repr_condition(self,v):
        return  "{{{}}}".format(",".join(map(str, v)))
    
    def sc_repr_datetime(self,v):
        datetimeformat = "{{{},{},{}}}".format
        return "\"{{{}, {}}}\"".format(datetimeformat(v["date"][0], v["date"][1], v["date"][2]), datetimeformat(v["time"][0], v["time"][1], v["time"][2]))
    
    def sc_repr_dict_int_SceneDieLua(self,v):
        fmt = '{{{}, {}, {}}}'.format
        kvs = ",".join(fmt(sc_repr_int(k["Value1"]),
                           sc_repr_int(k["Value2"]),
                           '\\"' + sc_repr_str(k["Value3"]).strip('"') + '\\"') for k in v)
        return '"{' + kvs + '}"'
    
        
        
        
        
    
        