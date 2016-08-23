using UnityEngine;

public class TotalManager : MonoBehaviour
{
    private static TotalManager _instance;

    public TotalManager()
    {
        _instance = this;
    }

    public static TotalManager GetInstance()
    {
        if (_instance != null)
        {
            return _instance;
        }
        GameObject go = new GameObject("TotalManager");
        DontDestroyOnLoad(go);

        return go.AddComponent<TotalManager>();
    }

    private TimerManager _timerManager;
    void Awake()
    {
        _timerManager = TimerManager.GetInstance();
    }

    void Update()
    {
        _timerManager.Update();
    }
}