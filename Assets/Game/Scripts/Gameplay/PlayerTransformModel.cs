using System;
using UnityEngine;

public class PlayerTransformModel
{
    public event Action TransformChanged;
        
    public Transform Transform { get; private set; }

    public PlayerTransformModel(Transform transform)
    {
        Transform = transform;
    }

    public void SetPlayerTransform(Transform transform)
    {
        Transform = transform;
        TransformChanged?.Invoke();
    }
}