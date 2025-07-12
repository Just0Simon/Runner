using UnityEngine;

public abstract class AbstractTweenEffect : ScriptableObject
{
    public abstract void Apply(Transform transform);
}