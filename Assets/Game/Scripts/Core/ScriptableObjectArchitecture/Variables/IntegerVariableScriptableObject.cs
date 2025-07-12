using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Variables/Integer",
    fileName = "New Integer Variable Event", order = 2)]
public class IntegerVariableScriptableObject : ScriptableObject
{
    public event Action<int> Changed;

    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            Changed?.Invoke(_value);
        }
    }
    
    private int _value;
    
    public void Reset()
    {
        _value = 0;
    }
    
    public static implicit operator int(IntegerVariableScriptableObject integerVariableScriptableObject)
    {
        return integerVariableScriptableObject.Value;
    }
}