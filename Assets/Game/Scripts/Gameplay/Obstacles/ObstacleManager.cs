using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField]
    private ObstacleTriggeredEvent _obstacleTriggeredEvent;
    [SerializeField]
    private ObstacleTriggeredEvent _winObstacleTriggeredEvent;
    
    [SerializeField]
    private GameOverScriptableObjectEvent _gameOverEvent;

    private void Awake()
    {
        _obstacleTriggeredEvent.Event += OnObstacleTriggered;
        _winObstacleTriggeredEvent.Event += OnWinObstacleTriggered;
    }

    private void OnDestroy()
    {
        _obstacleTriggeredEvent.Event -= OnObstacleTriggered;
        _winObstacleTriggeredEvent.Event -= OnWinObstacleTriggered;
    }

    private void OnWinObstacleTriggered(Obstacle obstacle)
    {
        _gameOverEvent.Invoke(true);
    }

    private void OnObstacleTriggered(Obstacle obj)
    {
        _gameOverEvent.Invoke(false);
    }
}