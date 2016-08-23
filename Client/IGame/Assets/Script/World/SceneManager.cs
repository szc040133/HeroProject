using UnityEngine;
using System.Collections;

public class SceneManager
{
    private static SceneManager _instance;
	public SceneManager()
    {
        if (_instance != null) throw new System.Exception("单件实例错误");
        _instance = this;

        OnLaunch();
    }

    public static SceneManager GetInstance()
    {
        if (_instance != null) return _instance;
        return new SceneManager();
    }

    private void OnLaunch()
    {
        _scene = new LaunchScene(0);
    }

    private SceneBase _scene;
    private SceneType _sceneType;
    private int _id;
    private bool _loading;
    public void LoadLevel(int id)
    {
        if (_loading) return;
        _loading = true;

        _id = id;
        _scene.Destroy();
        if (id == 0) _sceneType = SceneType.Launch;
        else _sceneType = SceneType.Norm;

        switch(_sceneType)
        {
            case SceneType.Launch:
                _scene = new LaunchScene(id);
                break;
            case SceneType.Norm:
                _scene = new NormScene(id);
                break;
        }

        TotalManager.GetInstance().StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(GameConfig.Scene[_id].name);
        new GameObject("Scene").AddComponent<SceneLaunch>();
        _loading = false;
    }


    public SceneBase Scene { get { return _scene; } }
    public SceneType SceneType { get { return _sceneType; } }
    public int Id { get { return _id; } }
    public NormScene NormScene { get { return _scene as NormScene; } }
}

public enum SceneType
{
    Launch,
    Norm,
}
