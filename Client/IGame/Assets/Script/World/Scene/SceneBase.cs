using UnityEngine;
using System.Collections;

public class SceneBase
{
    protected int _id;
    private int _grantId;

    protected CameraManager _cameraManager;

    public SceneBase(int id)
    {
        _id = id;

        _cameraManager = CameraManager.GetInstance();
    }

    public virtual void Start()
    {
        PoolManager.GetInstance().Start();
    }

    public virtual void Run()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void LateUpdate()
    {

    }

    public virtual void Destroy()
    {
        GameObject.Destroy(GameObject.Find("Scene"));
    }

    public int Id { get { return _id; } }

    public int GrantId
    {
        get
        {
            _grantId++;
            return _grantId;
        }
    }
}
