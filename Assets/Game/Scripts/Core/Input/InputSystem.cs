using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : IDisposable
{
    private readonly InputActionAsset _actionAsset;
        
    private readonly Dictionary<Type, IInputProcessor> _processorsMap;
        
    public InputSystem(InputActionAsset actionAsset)
    {
        _actionAsset = actionAsset;
        _processorsMap = new Dictionary<Type, IInputProcessor>();
    }

    public void AddProcessor<T>(T processor) where T : IInputProcessor
    {
        if(_processorsMap.ContainsKey(processor.GetType()))
        {
            Debug.LogError("You are trying to add processors that already exist");
            return;
        }
        
        processor.Initialize(_actionAsset);
        _processorsMap.Add(typeof(T), processor);
    }

    public T GetProcessor<T>() where T : IInputProcessor
    {
        if (_processorsMap.ContainsKey(typeof(T)) is false)
        {
            Debug.LogError("You are trying to get processors that does not exist");
            return default;
        }
            
        return (T)_processorsMap[typeof(T)];
    }

    public void Dispose()
    {
        foreach (var inputProcessor in _processorsMap.Values)
        {
            inputProcessor.Dispose();
        }
    }
}