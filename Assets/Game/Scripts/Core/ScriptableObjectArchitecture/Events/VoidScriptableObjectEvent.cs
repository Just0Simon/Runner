using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Void",
    fileName = "New Void Event", order = 2)]
public class VoidScriptableObjectEvent : ScriptableObject
{
    public event Action Event;

    public void Invoke()
    {
        Event?.Invoke();
    }
}