using System;
using System.Collections.Generic;
using UnityEngine;

public class EventDispatcher
{
	private static EventDispatcher _instance;
	public EventDispatcher()
	{
		if (_instance != null)
			throw new Exception("单件实例错误");
		_instance = this;
	}

	public static EventDispatcher GetInstance()
	{
		if (_instance != null)
		{
			return _instance;
		}
		return new EventDispatcher();
	}

	private readonly Dictionary<EVT, List<EventFunction>> _events = new Dictionary<EVT, List<EventFunction>>();

	public void AddEventListener(EVT evt, EventFunction listener)
	{
		if (!_events.ContainsKey(evt)) _events.Add(evt, new List<EventFunction>());
		_events[evt].Add(listener);
	}

	public void RemoveEventListener(EVT evt, EventFunction listener)
	{
		if (!_events.ContainsKey(evt)) return;
		_events[evt].Remove(listener);
	}

	public void DispatchEvent(EVT evt, object obj = null)
    {
		if (!_events.ContainsKey(evt)) return;
		List<EventFunction> listener = _events[evt];
		MyEvent mevt = new MyEvent(evt, obj);
		for (var i = 0; i < listener.Count; i++)
		{
			try
			{
				listener[i](mevt);
			}
			catch (Exception e)
			{
				Debug.LogException(e);
			}
        }
	}

	public void Dispose()
	{
		_events.Clear();
	}
}

public delegate void EventFunction(MyEvent evt);

public struct MyEvent
{
	private EVT _evt;
	private object _data;

	public MyEvent(EVT evt, object data)
	{
        _evt = evt;
		_data = data;
	}

	public EVT Event { get { return _evt; } }

	public object Data { get { return _data; } }
}

public enum EVT
{
    Test,
}