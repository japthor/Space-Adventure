using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
  // Play the game.
  public void Play()
  {
    GameManager.Instance.GameManagerElements.ResetValues();
    GameManager.Instance.ScenesManager.NextScene();
  }
  // Exits the game.
  public void Exit()
  {
    Application.Quit();
  }
}
