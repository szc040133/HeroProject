using UnityEngine;
using System.Collections;

public class LaunchScene : SceneBase
{
    public LaunchScene(int id)
        : base(id)
    {
        
    }

    public override void Start()
    {
        base.Start();
        L.Log("启动游戏。");
    }

    public override void Run()
    {
        base.Run();

        //SceneManager.GetInstance().LoadLevel(1);
    }
}
