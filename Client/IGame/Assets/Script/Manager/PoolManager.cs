using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class PoolManager
{
	private static PoolManager _instance;

	public PoolManager()
	{
		if (_instance != null)
			throw new Exception("单件实例错误");
		_instance = this;
	}

	public static PoolManager GetInstance()
	{
		if (_instance != null)
		{
			return _instance;
		}
		return new PoolManager();
	}

    private Dictionary<string, PoolTransform> _tfPool = new Dictionary<string, PoolTransform>();
	private Transform _poolManager;

    public void Start()
    {
        if (_poolManager == null)
        {
            _poolManager = new GameObject("PoolManager").transform;
            _poolManager.gameObject.SetActive(false);
        }
    }

	public Transform Take(string path, Vector3 pos = default(Vector3), Quaternion q = default(Quaternion))
	{
		if (!_tfPool.ContainsKey(path)) _tfPool.Add(path, new PoolTransform(path, _poolManager));
		return _tfPool[path].Take(pos, q);
	}

	public void Back(string path, Transform tf)
	{
		if (tf == null) return;
        if (_tfPool.ContainsKey(path)) _tfPool[path].Back(tf);
        else GameObject.Destroy(tf.gameObject);
	}

	public Transform Pool
	{
		get { return _poolManager; }
	}
}

public class PoolTransform
{
    private string _path;
    private Transform _parent;
    private ABDLManager _ABDLManager;

	private List<Transform> _list = new List<Transform>();
	private int _num;
    private string _sign;
	public PoolTransform(string path, Transform parent)
	{
        _path = path;
        _parent = parent;
        _sign = "PoolTransform-" + path;
        _ABDLManager = ABDLManager.GetInstance();
	}

	public Transform Take(Vector3 pos, Quaternion q)
	{
		_num++;
		Transform op;
		if (_list.Count > 0)
		{
			op = _list[0];
			_list.RemoveAt(0);
			op.parent = null;
		}
		else
		{
            var obj = _ABDLManager.GetAsset(_path, _sign);
			if (obj == null) return null;
			var obj2 = GameObject.Instantiate(obj) as GameObject;
			op = obj2.transform;
			op.name = op.name.Replace("(Clone)", "");
		}
		op.position = pos;
		op.rotation = q;
		return op;
	}

	public void Back(Transform tf)
	{
		if (_num == 0) return;
		if (_list.Contains(tf)) return;
		_num--;
		tf.parent = _parent;
		tf.localScale = Vector3.one;
		_list.Add(tf);
	}

    public void Unload()
    {
        if (_num > 0) return;
        for (int i = 0; i < _list.Count; i++)
        {
            GameObject.Destroy(_list[i].gameObject);
        }
        _list.Clear();
    }
}