using UnityEngine;
using System;
using System.Reflection;
using System.IO;

public class EngineManager
{
    private static EngineManager _instance;
    public EngineManager()
    {
        if (_instance != null) throw new Exception("单件实例错误");
        _instance = this;

        OnRun();
    }

    public static EngineManager GetInstance()
    {
        if (_instance != null) return _instance;
        return new EngineManager();
    }
    public string OutsideUrl;
    public string InsideUrl;
    public OperatingSystem OS;
    private Assembly _assembly;

    private void OnRun()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer
            || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer)
        {
            InsideUrl = OutsideUrl = "file:///" + Application.dataPath + Path.AltDirectorySeparatorChar + "StreamingAssets" + Path.AltDirectorySeparatorChar;
            OS = OperatingSystem.WINDOWS;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            InsideUrl = Application.streamingAssetsPath + Path.AltDirectorySeparatorChar;
            OutsideUrl = "file:///" + Application.persistentDataPath + Path.AltDirectorySeparatorChar;
            OS = OperatingSystem.ANDROID;
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            InsideUrl = "file:///" + Application.streamingAssetsPath + Path.AltDirectorySeparatorChar;
            OutsideUrl = "file:///" + Application.persistentDataPath + Path.AltDirectorySeparatorChar;
            OS = OperatingSystem.IOS;
        }
    }

    public void AddComponent(GameObject go, string name)
    {
        if(_assembly == null)
        {
            var l = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var a in l)
            {
                //Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
                var t = a.GetType(name);
                if (t != null)
                {
                    go.AddComponent(a.GetType(name));
                    return;
                }
            }
        }
        else go.AddComponent(_assembly.GetType(name));
    }
}

public enum OperatingSystem
{
    WINDOWS = 0,
    ANDROID = 1,
    IOS = 2
}
