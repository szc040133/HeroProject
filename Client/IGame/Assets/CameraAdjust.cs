using UnityEngine;
using System.Collections;

public class CameraAdjust : MonoBehaviour
{
    public Vector3 Position;
    public Vector3 Direction = new Vector3(0, 5, 5);
    public float Distance = 10;

    private Transform _transform;
	void Awake () {
        _transform = transform;
    }
	
	void Update () {
        _transform.position = Position + Direction.normalized * Distance;
        _transform.LookAt(Position);
    }
}
