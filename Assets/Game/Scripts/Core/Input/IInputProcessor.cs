using System;
using UnityEngine.InputSystem;

public interface IInputProcessor : IDisposable
{
    void Initialize(InputActionAsset actionAsset);
}