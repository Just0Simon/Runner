using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField]
    private IntegerVariableScriptableObject _gameScoreVariable;
    
    [SerializeField]
    private GameOverScriptableObjectEvent _gameOverEvent;
    [SerializeField]
    private VoidScriptableObjectEvent _replayEvent;
    [SerializeField]
    private VoidScriptableObjectEvent _mainMenuEvent;

    private PlayerController _player;
    
    private void Awake()
    {
        _gameOverEvent.Event += OnGameOver;
        _replayEvent.Event += Replay;
        _mainMenuEvent.Event += MainMenu;
    }

    private void OnDestroy()
    {
        _gameOverEvent.Event -= OnGameOver;
        _replayEvent.Event -= Replay;
        _mainMenuEvent.Event -= MainMenu;
    }

    public void Initialize(PlayerController player)
    {
        _player = player;
    }

    private void OnGameOver(bool win)
    {
        _player.Stop();
    }
    
    private void MainMenu()
    {
        ProjectSceneManager.LoadMainMenuScene();
    }
    
    private void Replay()
    {
        _gameScoreVariable.Reset();
        ProjectSceneManager.LoadGameplayScene();
    }
}