using UnityEngine;

[CreateAssetMenu(menuName = "Configuration/Input/Swipe Configuration",
    fileName = "New Swipe Configuration", order = 2)]
public class SwipeConfiguration : ScriptableObject
{
    [field: SerializeField]
    [Tooltip("Minimum distance for a swipe (in pixels)")]
    public float SwipeThreshold { get; private set; }= 100f;
    [field: SerializeField]
    [Tooltip("Threshold for dot production of the swipe direction and jump direction(in percentage).")]
    public float SwipeDirectionMatchThreshold { get; private set; } = 0.75f;
    
    [field: SerializeField]
    [Tooltip("Maximum swipe time duration (in seconds).")]
    public float SwipeTimeThreshold { get; private set; }= 0.5f;
}