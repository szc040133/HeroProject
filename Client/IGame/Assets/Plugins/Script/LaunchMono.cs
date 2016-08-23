using UnityEngine;

public class LaunchMono : MonoBehaviour {

    void Awake()
    {
        EngineManager.GetInstance().AddComponent(this.gameObject, "SceneLaunch");
        GameObject.DestroyImmediate(this);
    }
	
}
