using UnityEngine;

public class GameManager : MonoBehaviour
{
  // Global Instance
  private static GameManager m_Instance;
  // Game elements manager instance
  private GameManagerElements m_GameManagerElements;
  // Scenes manager instance
  private ScenesManager m_ScenesManager;

  // Setter/Getters
  public static GameManager Instance
  {
    get { return m_Instance; }
    private set { Instance = value; }
  }
  public GameManagerElements GameManagerElements
  {
    get { return m_GameManagerElements; }
    private set { m_GameManagerElements = value; }
  }
  public ScenesManager ScenesManager
  {
    get { return m_ScenesManager; }
    private set { m_ScenesManager = value; }
  }

  private void Awake()
  {
    if (m_Instance == null)
    {
      m_Instance = this;
      DontDestroyOnLoad(gameObject);

      m_ScenesManager = new ScenesManager();
      m_GameManagerElements = new GameManagerElements();
    }
    else
      Destroy(this);
  }

  private void OnEnable()
  {
    if (m_GameManagerElements != null)
      m_GameManagerElements.LoseEvent += GameOver;
  }

  private void OnDisable()
  {
    if (m_GameManagerElements != null)
      m_GameManagerElements.LoseEvent -= GameOver;
  }

  // Changes to gameover scene
  private void GameOver()
  {
    if (m_ScenesManager != null)
      m_ScenesManager.NextScene();
  }
}
