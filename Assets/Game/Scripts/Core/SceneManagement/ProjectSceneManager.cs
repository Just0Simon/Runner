using UnityEngine.SceneManagement;

public class ProjectSceneManager
{
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(Constants.MainMenuScene);
    }

    public void LoadGameplayScene()
    {
        SceneManager.LoadScene(Constants.GameplayScene);
    }
}