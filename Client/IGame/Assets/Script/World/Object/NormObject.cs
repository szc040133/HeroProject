using UnityEngine;
using System.Collections;

public class NormObject : ObjectBase
{
    private IAnimation _animation;
    private NormScene _scene;
    public NormObject(int id)
        : base(id)
    {
        _scene = SceneManager.GetInstance().NormScene;
        _scene.AddObject(this);
    }

    public virtual void Infuse(NormVO vo)
    {

    }

    public override void Start()
    {
        base.Start();
    }

    public override void Destroy()
    {
        _scene.RemoveObject(this);

        base.Destroy();
    }

    public IAnimation Animation { get { return _animation; } }
}

public struct NormVO
{
    public int Road;
    public NormVO(int road)
    {
        Road = road;
    }
}
