using TMPro;
using UnityEngine;

public class ScoreInterface : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _gameScoreText;
    
    [SerializeField]
    private IntegerVariableScriptableObject _gameScoreVariable;

    private void Awake()
    {
        _gameScoreVariable.Changed += OnGameScoreChanged;
    }

    private void OnDestroy()
    {
        _gameScoreVariable.Changed -= OnGameScoreChanged;
    }

    private void OnGameScoreChanged(int newValue)
    {
        _gameScoreText.text = newValue.ToString();
    }
}