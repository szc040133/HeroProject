using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NormScene : SceneBase
{
    protected ArrangeType _arrange;
    protected List<NormObject> _objects = new List<NormObject>();
    protected int _road;

    public NormScene(int id)
        :base(id)
    {
        _arrange = (ArrangeType)GameConfig.Scene[id].arrange;
        _road = GameConfig.Scene[id].road;
    }

    public override void Start()
    {
        base.Start();

        GameObject.Instantiate(ABDLManager.GetInstance().GetAsset("Scene/Level" + GameConfig.Scene[_id].name));
    }

    public override void Run()
    {
        base.Run();

        _cameraManager.Run();
    }

    public override void LateUpdate()
    {
        base.LateUpdate();

        _cameraManager.LateUpdate();
    }

    public void AddObject(NormObject obj)
    {
        _objects.Add(obj);
    }

    public void RemoveObject(NormObject obj)
    {
        _objects.Remove(obj);
    }

    public override void Destroy()
    {
        foreach(var obj in _objects)
        {
            obj.Destroy();
        }
        _objects.Clear();

        base.Destroy();
    }

    public ArrangeType Arrange{ get { return _arrange; } }
    public List<NormObject> Objects { get { return _objects; } }
    public int Road { get { return _road; } }
}

