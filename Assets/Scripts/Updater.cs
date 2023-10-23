using UnityEngine;

using System.Collections.Generic;
using UnityEngine;

public class Updater : MonoBehaviour
{
    private readonly List<IUpdateListener> _listeners = new();

    public void AddListener(params IUpdateListener[] listeners)
    {
        foreach (var listener in listeners)
        {
            if (!_listeners.Contains(listener)) _listeners.Add(listener);
        }
    }
        
    public void RemoveListener(params IUpdateListener[] listeners)
    {
        foreach (var listener in listeners)
        {
            if (_listeners.Contains(listener)) _listeners.Remove(listener);
        }
    }

    private void Update()
    {
        for (var i = 0; i < _listeners.Count; i++)
        {
            _listeners[i].Updater(Time.deltaTime);
        }
    }
}