using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuInterface : MonoBehaviour
{
    public event Action PlayPressed;
    public event Action ExitPressed;
    
    [SerializeField]
    private Button _playButton;
    [SerializeField]
    private Button _aboutButton;
    [SerializeField]
    private Button _quitButton;
    
    [SerializeField]
    private AboutInterface _aboutInterface;

    private void Awake()
    {
        _playButton.onClick.AddListener(OnPlayPressed);
        _aboutButton.onClick.AddListener(OnAboutPressed);
        _quitButton.onClick.AddListener(OnExitPressed);
        _aboutInterface.ClosePressed += OnAboutClosed;
    }

    private void OnPlayPressed()
    {
        PlayPressed?.Invoke();
    }

    private void OnExitPressed()
    {
        ExitPressed?.Invoke();
    }

    private void OnAboutPressed()
    {
        _aboutInterface.Show();
    }

    private void OnAboutClosed()
    {
        _aboutInterface.Hide();
    }
    
    private void OnDestroy()
    {
        _playButton.onClick.RemoveAllListeners();
        _aboutButton.onClick.RemoveAllListeners();
        _quitButton.onClick.RemoveAllListeners();
        _aboutInterface.ClosePressed -= OnAboutPressed;
    }
}
