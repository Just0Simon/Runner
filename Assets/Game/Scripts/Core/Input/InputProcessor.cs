using System;
using UnityEngine.InputSystem;

public abstract class InputProcessor : IDisposable
{
    protected InputActionAsset ActionAsset;

    public virtual void Initialize(InputActionAsset actionAsset)
    {
        ActionAsset = actionAsset;
    }

    public abstract void Dispose();
}