using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField]
    private MainMenuInterface _mainMenuInterfacePrefab;

    private MainMenuInterface _mainMenuInterfaceInstance;
    
    private void Awake()
    {
        
        _mainMenuInterfaceInstance = Instantiate(_mainMenuInterfacePrefab);
        _mainMenuInterfaceInstance.PlayPressed += OnPlayPressed;
        _mainMenuInterfaceInstance.ExitPressed += OnExitPressed;
    }

    private void OnPlayPressed()
    {
        ProjectSceneManager.LoadGameplayScene();
    }

    private void OnExitPressed()
    {
        Application.Quit();   
    }

    private void OnDestroy()
    {
        _mainMenuInterfaceInstance.PlayPressed -= OnPlayPressed;
        _mainMenuInterfaceInstance.ExitPressed -= OnExitPressed;
    }
}
