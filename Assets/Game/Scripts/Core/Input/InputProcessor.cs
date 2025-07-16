using System;
using UnityEngine.InputSystem;

public abstract class InputProcessor : IInputProcessor
{
    protected InputActionAsset ActionAsset;

    public virtual void Initialize(InputActionAsset actionAsset)
    {
        ActionAsset = actionAsset;
    }

    public abstract void Dispose();
}