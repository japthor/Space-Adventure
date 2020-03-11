using System.Collections;
using UnityEngine;


public class EnemiesSpawner : MonoBehaviour
{
  // Reference to the Pool Objects
  private ObjectPooling m_Pool;
  // Minimum time for spawning.
  [SerializeField] private float m_MinTime;
  // Max time for spawning.
  [SerializeField] private float m_MaxTime;
  // Minimum quantity of objects
  [SerializeField] private int m_MinObjects;
  // Maximum quantity of objects
  [SerializeField] private int m_MaxObjects;
  // Position to Spawn
  [SerializeField] Collider2D m_SpawnPoint;

  // Randomized time value.
  private float m_Timer;
  // Randomized total objects to spawn value.
  private int m_TotalObjects;

  // Setters/Getters
  public ObjectPooling Pool
  {
    get { return m_Pool; }
    private set { m_Pool = value; }
  }
  public float MinTime
  {
    get { return m_MinTime; }
    private set { m_MinTime = value; }
  }
  public float MaxTime
  {
    get { return m_MaxTime; }
    private set { m_MaxTime = value; }
  }
  public int MinObjects
  {
    get { return m_MinObjects; }
    private set { m_MinObjects = value; }
  }
  public int MaxObjects
  {
    get { return m_MaxObjects; }
    private set { m_MaxObjects = value; }
  }
  public Collider2D SpawnPoint
  {
    get { return m_SpawnPoint; }
    private set { m_SpawnPoint = value; }
  }
  public float Timer
  {
    get { return m_Timer; }
    private set { m_Timer = value; }
  }
  public int TotalObjects
  {
    get { return m_TotalObjects; }
    private set { m_TotalObjects = value; }
  }

  private void Awake()
  {
    m_Pool = GetComponent<ObjectPooling>();
  }

  private void Start()
  {
    ResetValues();
    StartCoroutine();
  }

  private void OnEnable()
  {
    GameManager.Instance.GameManagerElements.ResetEvent += StopCoroutine;
    GameManager.Instance.GameManagerElements.ResetEvent += StartCoroutine;
    GameManager.Instance.GameManagerElements.LoseEvent += StopCoroutine;
  }
  private void OnDisable()
  {
    GameManager.Instance.GameManagerElements.ResetEvent -= StopCoroutine;
    GameManager.Instance.GameManagerElements.ResetEvent -= StartCoroutine;
    GameManager.Instance.GameManagerElements.LoseEvent -= StopCoroutine;
  }

  // Randomize timer. 
  private void RandomTime()
  {
    m_Timer = Random.Range(m_MinTime, m_MaxTime);
  }

  // Randomize the quantity of objects to spwawn.
  private void RandomTotalObjects()
  {
    m_TotalObjects = Random.Range(m_MinObjects, m_MaxObjects + 1);
  }

  private IEnumerator CountDown()
  {
    while (true)
    {
      yield return new WaitForSeconds(m_Timer);
      Spawn();
      ResetValues();
    }
  }

  // Activates an object from the pool.
  private void Spawn()
  {
    if (m_Pool != null)
    {
      for(int i = 0; i < m_TotalObjects; i++)
      {
        GameObject asteroid = m_Pool.GetPooledObject();

        if (asteroid != null)
        {
          asteroid.transform.position = RandomPoint(m_SpawnPoint.bounds);
          asteroid.SetActive(true);
        }
      }
    }
  }

  // Gets a random position inside a bound.
  public Vector2 RandomPoint(Bounds bounds)
  {
    return new Vector2
    (
        Random.Range(bounds.min.x, bounds.max.x),
        Random.Range(bounds.min.y, bounds.max.y)
    );
  }

  // Reset values.
  private void ResetValues()
  {
    RandomTime();
    RandomTotalObjects();
  }

  // Starts the spawn cycle
  private void StartCoroutine()
  {
    StartCoroutine(CountDown());
  }
  // Stops the spawn cycle
  private void StopCoroutine()
  {
    StopAllCoroutines();
  }
}
