using System;
using UnityEngine;

public abstract class GenericScriptableObjectEvent<T> : ScriptableObject
{
    public event Action<T> Event;

    public void Invoke(T value)
    {
        Event?.Invoke(value);
    }
}