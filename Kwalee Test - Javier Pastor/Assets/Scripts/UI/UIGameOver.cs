using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
  // Reference to the score text
  [SerializeField] private TextMeshProUGUI m_Score = null;
  // Reference to the highscore text
  [SerializeField] private TextMeshProUGUI m_HighScore = null;

  private void Start()
  {
    UpdateScore();
    UpdateHighScore();
  }

  // Updates the score
  private void UpdateScore()
  {
    if (m_Score != null)
      m_Score.text = GameManager.Instance.GameManagerElements.Score.ToString();
  }
  // Updates the high score
  private void UpdateHighScore()
  {
    if (m_HighScore != null)
      m_HighScore.text = GameManager.Instance.GameManagerElements.HighScore.ToString();
  }

  // Plays the game again.
  public void PlayAgain(int scene)
  {
    GameManager.Instance.GameManagerElements.ResetValues();
    GameManager.Instance.ScenesManager.LoadScene(scene);
  }
  // Goes to the main menu.
  public void MainMenu()
  {
    GameManager.Instance.ScenesManager.LoadMainMenu();
  }
}