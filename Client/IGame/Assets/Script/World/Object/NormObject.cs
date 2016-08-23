using UnityEngine;
using System.Collections;

public class NormObject : ObjectBase
{
    private IAnimation _animation;
    private NormScene _scene;
    private int _road;
    private float _position;
    private Camp _camp;

    public NormObject(int id)
        : base(id)
    {
        _scene = SceneManager.GetInstance().NormScene;
        _scene.AddObject(this);
    }

    public virtual void Infuse(NormVO vo)
    {
        _road = vo.Road;
        _position = vo.Position;
        _camp = vo.Camp;
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
    public int RoleId;
    public int Road;
    public float Position;
    public Camp Camp;
    public NormVO(int roleId, int road, float position, Camp camp)
    {
        RoleId = roleId;
        Road = road;
        Position = position;
        Camp = camp;
    }
}
