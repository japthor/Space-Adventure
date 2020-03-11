using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerElements
{
  // Highscore value
  private int m_HighScore;
  // Score value
  private int m_Score;

  // Setters/Getters
  public int Score
  {
    get { return m_Score; }
    private set { m_Score = value; }
  }
  public int HighScore
  {
    get { return m_HighScore; }
    private set { m_HighScore = value; }
  }

  // Delegates/Events for updating score
  public delegate void UIDelegate();
  public event UIDelegate ScoreEvent;

  // Delegates/Events for Lose/Die events
  public delegate void GameManagerDelegate();
  public event GameManagerDelegate LoseEvent;
  public event GameManagerDelegate ResetEvent;

  public GameManagerElements()
  {
    m_HighScore = PlayerPrefs.GetInt("HighScore", 0);
    m_Score = 0;
  }

  // Add score.
  public void AddScore(int value)
  {
    m_Score += value;
    ScoreEvent();
  }
  // Subtract score.
  public void SubtractScore(int value)
  {
    if ((m_Score - value) < 0)
      m_Score = 0;
    else
      m_Score -= value;

    ScoreEvent();
  }
  // Fires lose event.
  public void FireLoseEvent()
  {
    CheckHighScore();
    LoseEvent();
  }
  // Fires reset event.
  public void FireResetEvent()
  {
    ResetEvent();
  }
  // Check if there is a new highscore and saves it.
  private void CheckHighScore()
  {
    if(m_Score > PlayerPrefs.GetInt("HighScore"))
    {
      m_HighScore = m_Score;
      PlayerPrefs.SetInt("HighScore", m_HighScore);
      PlayerPrefs.Save();
    }
  }
  // Reset values.
  public void ResetValues()
  {
    HighScore = PlayerPrefs.GetInt("HighScore");
    m_Score = 0;
  }
}
