using System;
using UnityEngine;

public interface ITouchInputProcessor : IInputProcessor
{
    event Action Started;
    event Action<Vector2> Performed;
    event Action Canceled;
    
    bool IsTouching { get; }
    
    Vector2 GetPosition();
    Vector2 GetDelta();
}