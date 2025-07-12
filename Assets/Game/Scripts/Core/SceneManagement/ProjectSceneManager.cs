using UnityEngine.SceneManagement;

public static class ProjectSceneManager
{
    public static void LoadMainMenuScene()
    {
        SceneManager.LoadScene(Constants.MainMenuScene);
    }

    public static void LoadGameplayScene()
    {
        SceneManager.LoadScene(Constants.GameplayScene);
    }
}