using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    public ObstacleTriggeredEvent _obstacleTriggeredEvent;
    
    [SerializeField]
    [Tooltip("Leave empty if you want the obstacle not to be effected")]
    private AbstractTweenEffect _onTriggerEffect;
    
    // Obstacle matrix collision setup only for Player's layer
    public virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        
        _obstacleTriggeredEvent.Invoke(this);   
        _onTriggerEffect?.Apply(transform);
    }
}