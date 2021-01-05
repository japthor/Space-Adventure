using TMPro;
using UnityEngine;

public class UIGame : MonoBehaviour
{
  // reference to score text
  [SerializeField] private TextMeshProUGUI m_Score = null;
  // reference to life text
  [SerializeField] private TextMeshProUGUI m_Life = null;
  // Reference to the spaceship.
  private PlayerSpaceship m_SpaceShip;

  private void Awake()
  {
    m_SpaceShip = FindObjectOfType<PlayerSpaceship>();
  }

  private void Start()
  {
    UpdateScore();
    UpdateLife();
  }
  private void OnEnable()
  {
    if(m_SpaceShip != null)
    {
      m_SpaceShip.LifeEvent += UpdateLife;
      GameManager.Instance.GameManagerElements.ScoreEvent += UpdateScore;
    }
  }
  private void OnDisable()
  {
    if (m_SpaceShip != null)
    {
      m_SpaceShip.LifeEvent -= UpdateLife;
      GameManager.Instance.GameManagerElements.ScoreEvent -= UpdateScore;
    }
  }
  // Updates the score
  private void UpdateScore()
  {
    if (m_Score != null)
      m_Score.text = GameManager.Instance.GameManagerElements.Score.ToString();
  }
  // Updates the life
  private void UpdateLife()
  {
    if (m_Life != null)
      m_Life.text = m_SpaceShip.Life.ToString();
  }
}
