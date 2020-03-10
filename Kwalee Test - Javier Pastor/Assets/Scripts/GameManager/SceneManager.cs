using UnityEngine.SceneManagement;

public class ScenesManager
{
  public ScenesManager() { }

  // Loads a new scene.
  public void LoadScene(int scene)
  {
    if (scene <= SceneManager.sceneCountInBuildSettings)
      SceneManager.LoadScene(scene);
  }

  // Loads the main menu.
  public void LoadMainMenu()
  {
    SceneManager.LoadScene(0);
  }

  // Changes to the next scene
  public void NextScene()
  {
    int current = SceneManager.GetActiveScene().buildIndex + 1;

    if (current <= SceneManager.sceneCountInBuildSettings)
      SceneManager.LoadScene(current);
  }
}
