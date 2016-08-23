using UnityEngine;
using System.Collections;

public class ObjectBase
{
    protected int _id;
    protected Transform _root;
    public ObjectBase(int id)
    {
        _id = id;
        _root = new GameObject(id.ToString()).transform;
    }

    public virtual void Start()
    {

    }

    public virtual void Run()
    {

    }

    public virtual void Destroy()
    {
        GameObject.Destroy(_root);
    }

    public int Id { get { return _id; } }
    public Transform Root { get { return _root; } }
}
