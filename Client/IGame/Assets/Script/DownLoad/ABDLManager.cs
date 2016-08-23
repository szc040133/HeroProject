using UnityEngine;
using System.Collections;

public class ABDLManager
{
    private static ABDLManager _instance;
    public ABDLManager()
    {
        if (_instance != null) throw new System.Exception("单件实例错误");
        _instance = this;
    }

    public static ABDLManager GetInstance()
    {
        if (_instance != null) return _instance;
        return new ABDLManager();
    }

    public Object GetAsset(string path, string sign = "")
    {
        return Resources.Load(path);
    }
}
