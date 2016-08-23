using UnityEngine;

public class SceneLaunch : MonoBehaviour
{
    private SceneBase _scene;
    void Awake()
    {
        TotalManager.GetInstance();
        _scene = SceneManager.GetInstance().Scene;
    }

    void Start()
    {
        _scene.Start();
        _scene.Run();
    }

    void Update()
    {
        _scene.Update();
    }

    void LateUpdate()
    {
        _scene.LateUpdate();
    }
}
