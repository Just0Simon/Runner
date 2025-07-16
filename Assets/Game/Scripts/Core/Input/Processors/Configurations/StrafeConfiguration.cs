using UnityEngine;

[CreateAssetMenu(menuName = "Configuration/Input/Strafe Configuration",
    fileName = "New Strafe Configuration", order = 2)]
public class StrafeConfiguration : ScriptableObject
{
    [field: SerializeField]
    [Tooltip("Direction change threshold help smooth input lag.")]
    public float DirectionChangeThreshold { get; set; } = 0.1f;
    
    [field: SerializeField]
    [Tooltip("Direction match threshold help filter swipe from strafe.")]
    public float DirectionMatchThreshold { get; set; } = 0.3f;
}