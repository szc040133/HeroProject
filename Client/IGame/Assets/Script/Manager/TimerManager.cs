using System;
using System.Collections.Generic;
using UnityEngine;

public delegate void TimerFunc();
public class TimerManager
{
    private static TimerManager _instance;
    public TimerManager()
    {
        if (_instance != null)
            throw new Exception("单件实例错误");
        _instance = this;
    }

    public static TimerManager GetInstance()
    {
        if (_instance != null)
        {
            return _instance;
        }
        return new TimerManager();
    }

    private List<Timer> _timers = new List<Timer>();
    private float _quick = 1f;

    public void Update()
    {
        var timers = _timers.ToArray();
        for (int i = 0; i < timers.Length; i++)
        {
            timers[i].Update();
        }
    }

    public void EnterScene()
    {
        
    }

    public void ExitScene()
    {
        var timers = _timers.ToArray();
        for (int i = 0; i < timers.Length; i++)
        {
            timers[i].DestroyToScene();
        }
    }

    public void AddTimer(Timer timer)
    {
        _timers.Add(timer);
    }

    public void RemoveTimer(Timer timer)
    {
        _timers.Remove(timer);
    }

    public void Dispose()
    {
        _timers.Clear();
    }

    public float Quick
    {
        get { return _quick; }
        set
        {
            _quick = value;
            for (int i = 0; i < _timers.Count; i++)
            {
                _timers[i].ChangeQuick();
            }
        }
    }
}

public class Timer
{
    private float _startTime;
    private float _nextTime;
    private int _time;
    private float _initialDelay;
    private float _delay;
    private TimerFunc _timeFun;
    private bool _isQuick;
    private bool _destroyForExitScene;
    private bool _isDestroy;

    private bool _stop;
    private TimerManager _timerManager;

    /// <param name="delay">响应间隔</param>
    /// <param name="timeFun">回调</param>
    /// <param name="time">次数(0无限次)</param>
    /// <param name="isQuick">是否受加速作用</param>
    /// <param name="destroyForExitScene">退出场景时销毁</param>
    public Timer(float delay, TimerFunc timeFun, int time = 0, bool isQuick = false, bool destroyForExitScene = false)
    {
        if (delay <= 0)
        {
            _isDestroy = true;
            timeFun();
            return;
        }
        _startTime = Time.realtimeSinceStartup;
        _delay = _initialDelay = delay;
        _timeFun = timeFun;
        _time = time;
        _isQuick = isQuick;
        _destroyForExitScene = destroyForExitScene;
        _nextTime = _startTime + _delay;

        _timerManager = TimerManager.GetInstance();
        ChangeQuick();
        _timerManager.AddTimer(this);
    }

    internal void Update()
    {
        if (_stop) return;
        if (Time.realtimeSinceStartup >= _nextTime)
        {
            _startTime = _nextTime;
            _nextTime += _delay;
            try
            {
                if (!_isDestroy) _timeFun();
            }
            catch (Exception e)
            {
                Debug.LogError("TimerError: " + e.ToString());
                Debug.LogException(e);
            }
            finally
            {
                if (_time > 0)
                {
                    _time--;
                    if (_time == 0) Destroy();
                }
            } 
        }
    }

    private float _lsTime;
    internal void ChangeQuick()
    {
        if (!_isQuick) return;
        float n = _timerManager.Quick;
        if (n == 0)
        {
            if (_stop) return;
            _lsTime = Time.realtimeSinceStartup;
            _stop = true;
            return;
        }
        if (_stop)
        {
            _stop = false;
            _nextTime += (Time.realtimeSinceStartup - _lsTime);
        }
        float m = (_nextTime - Time.realtimeSinceStartup) / _delay;
        _delay = _initialDelay / n;
        _nextTime = Time.realtimeSinceStartup + m * _delay;
    }

    internal void DestroyToScene()
    {
        if (_destroyForExitScene) Destroy();
    }

    public void Destroy()
    {
        _isDestroy = true;
        _timerManager.RemoveTimer(this);
    }

    public bool IsDestroy
    {
        get { return _isDestroy; }
    }
}
