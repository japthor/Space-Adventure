using UnityEngine;
public class ExtraPointsPowerUp : PowerUp
{
  // Maximum points
  [SerializeField] private int m_MaxPoints;
  // Minimum points
  [SerializeField] private int m_MinPoints;
  // Actual given points
  private int m_Points;

  // Setters/Getters
  public int MaxPoints
  {
    get { return m_MaxPoints; }
    private set { m_MaxPoints = value; }
  }
  public int MinPoints
  {
    get { return m_MinPoints; }
    private set { m_MinPoints = value; }
  }
  public int Points
  {
    get { return m_Points; }
    private set { m_Points = value; }
  }

  protected override void Awake()
  {
    base.Awake();
  }

  private void Start()
  {
    RandomPoints();
  }
  protected override void OnEnable()
  {
    base.OnEnable();
  }
  protected override void OnDisable()
  {
    base.OnDisable();
  }

  // Adds points
  protected override void OnTriggerEnter2D(Collider2D collision)
  {
    base.OnTriggerEnter2D(collision);

    if (collision.gameObject.layer == LayerMask.NameToLayer("Spaceship"))
    {
      GameManager.Instance.GameManagerElements.AddScore(m_Points);
      Destroy();
    }
  }

  // Random points
  private void RandomPoints()
  {
    m_Points = Random.Range(m_MinPoints, m_MaxPoints + 1);
  }
}
