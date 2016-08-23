using UnityEngine;
using System.Collections;

public class WorldCamera
{
    private Transform _root;
    public WorldCamera()
    {
        _root = ((GameObject)GameObject.Instantiate(ABDLManager.GetInstance().GetAsset("NA/WorldCamera"))).transform;
    }

    public void LateUpdate()
    {

    }
}
