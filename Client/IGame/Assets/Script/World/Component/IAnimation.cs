using UnityEngine;
using System.Collections;

public class IAnimation
{
    private Animation _animation;
    public IAnimation()
    {

    }

    public void Start(Animation anim)
    {
        _animation = anim;
    }

    public void Play(string action)
    {
        _animation.Play(action);
    }
}
