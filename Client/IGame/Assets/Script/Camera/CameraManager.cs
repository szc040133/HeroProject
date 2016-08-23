using UnityEngine;
using System.Collections;

public class CameraManager
{
    private static CameraManager _instance;
    public CameraManager()
    {
        if (_instance != null) throw new System.Exception("单件实例错误");
        _instance = this;
    }

    public static CameraManager GetInstance()
    {
        if (_instance != null) return _instance;
        return new CameraManager();
    }
    private WorldCamera _worldCamera;
    public void Run()
    {
        _worldCamera = new WorldCamera();
    }

    public void LateUpdate()
    {
        _worldCamera.LateUpdate();
    }

    public WorldCamera WorldCamera { get { return _worldCamera; } }
}
