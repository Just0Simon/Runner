using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AboutInterface : MonoBehaviour
{
    public event Action ClosePressed;
    
    [SerializeField]
    private Button _closeButton;

    [SerializeField]
    private TMP_Text _attributionsText;
    
    [SerializeField]
    private CanvasGroup _canvasGroup;
    
    [SerializeField]
    private AttributionsConfiguration _attributionsConfiguration;
    
    private void Awake()
    {
        _closeButton.onClick.AddListener(OnClosePressed);
        _attributionsText.text = _attributionsConfiguration.GetAttributionsString();
    }

    private void OnDestroy()
    {
        _closeButton.onClick.RemoveAllListeners();
    }

    public void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
    
    private void OnClosePressed()
    {
        ClosePressed?.Invoke();
    }
}