using System;
using UnityEngine;

public class GameplayInterface : MonoBehaviour
{
    [SerializeField]
    private GameResultInterface _gameResultInterface;
    
    [SerializeField]
    private ScoreInterface _scoreInterface;
    
    [SerializeField]
    private GameOverScriptableObjectEvent _gameOverEvent;

    private void Awake()
    {
        _gameOverEvent.Event += ShowGameResult;
    }

    private void OnDestroy()
    {
        _gameOverEvent.Event -= ShowGameResult;
    }

    public void ShowGameResult(bool win)
    {
        _gameResultInterface.Show(win);
    }

    public void HideGameResult()
    {
        _gameResultInterface.Hide();
    }
}