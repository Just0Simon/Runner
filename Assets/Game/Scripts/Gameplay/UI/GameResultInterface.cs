using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameResultInterface : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _gameResultText;
    [SerializeField]
    private TMP_Text _gameScoreText;
    [SerializeField]
    private Button _menuButton;
    [SerializeField]
    private Button _replayButton;
    [SerializeField]
    private CanvasGroup _canvasGroup;

    [SerializeField]
    private float _showResultsDelay = 1f;
    [SerializeField]
    private float _fadeDuration = 0.2f;
    [SerializeField]
    private string _winMessage = "You win!";
    [SerializeField]
    private string _loseMessage = "You lose!";
    
    [SerializeField]
    private IntegerVariableScriptableObject _gameScoreVariable;
    [SerializeField]
    private VoidScriptableObjectEvent _replayEvent;
    [SerializeField]
    private VoidScriptableObjectEvent _mainMenuEvent;
    
    private void Awake()
    {
        _replayButton.onClick.AddListener(OnReplayButtonPressed);
        _menuButton.onClick.AddListener(OnMenuButtonPressed);
    }

    private void OnDestroy()
    {
        _replayButton.onClick.RemoveAllListeners();
        _menuButton.onClick.RemoveAllListeners();
    }

    public void Show(bool win)
    {
        _gameResultText.text = win ? _winMessage : _loseMessage;
        _gameScoreText.text = _gameScoreVariable.Value.ToString();
        
        var sequence = DOTween.Sequence();

        sequence.AppendInterval(_showResultsDelay);

        var tween = DOTween.To(() => _canvasGroup.alpha, x => _canvasGroup.alpha = x, 1, _fadeDuration);
        
        sequence.Append(tween);
        sequence.AppendCallback(OnShown);
        
        void OnShown()
        {
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
    }

    public void Hide()
    {
        DOTween.To(() => _canvasGroup.alpha, x => _canvasGroup.alpha = x, 0, _fadeDuration)
            .OnComplete(OnHidden);
        
        void OnHidden()
        {
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
    
    private void OnReplayButtonPressed()
    {
        _replayEvent?.Invoke();
    }

    private void OnMenuButtonPressed()
    {
        _mainMenuEvent?.Invoke();
    }
}