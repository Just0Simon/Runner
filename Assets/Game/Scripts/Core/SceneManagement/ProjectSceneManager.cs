using UnityEngine.SceneManagement;

public static class ProjectSceneManager
{
    public static void LoadMainMenuScene()
    {
        SceneManager.LoadScene(Constants.MAIN_MENU_SCENE);
    }

    public static void LoadGameplayScene()
    {
        SceneManager.LoadScene(Constants.GAMEPLAY_SCENE);
    }
}