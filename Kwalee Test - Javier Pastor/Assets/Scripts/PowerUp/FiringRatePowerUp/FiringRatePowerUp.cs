using System.Collections;
using UnityEngine;

public class FiringRatePowerUp : PowerUp
{
  // Firing rate
  [SerializeField] private float m_FiringRate;
  // Timer
  [SerializeField] protected float m_Timer;
  // Current time
  private float m_CurrentTime;
  // Reference to UnitShooting
  private UnitShooting m_SpaceshipShooting;

  // Setters/Getters
  public float FiringRate
  {
    get { return m_FiringRate; }
    private set { m_FiringRate = value; }
  }
  public float CurrentTime
  {
    get { return m_CurrentTime; }
    set { m_CurrentTime = value; }
  }
  public float Timer
  {
    get { return m_Timer; }
    set { m_Timer = value; }
  }

  protected override void Awake()
  {
    base.Awake();
  }

  protected override void OnEnable()
  {
    GameManager.Instance.GameManagerElements.ResetEvent += StopCoroutine;
    base.OnEnable();
  }
  protected override void OnDisable()
  {
    GameManager.Instance.GameManagerElements.ResetEvent -= StopCoroutine;
    base.OnDisable();
  }

  protected override void OnTriggerEnter2D(Collider2D collision)
  {
    base.OnTriggerEnter2D(collision);

    if (collision.gameObject.layer == LayerMask.NameToLayer("Spaceship"))
    {
      if (m_SpaceshipShooting == null)
        m_SpaceshipShooting = collision.GetComponent<UnitShooting>();

      if (m_SpaceshipShooting != null)
      {
        StartCoroutine(CountDown());
        Deactivate();
      }
    }
  }

  // Applies the powerup.
  private IEnumerator CountDown()
  {
    m_CurrentTime = m_Timer;
    DecreaseFiringRate();

    while (m_CurrentTime > 0)
    {
      yield return new WaitForSeconds(1.0f);
      m_CurrentTime--;
    }

    IncreaseFiringRate();
    Destroy();
  }

  // Stops the coroutine
  private void StopCoroutine()
  {
    StopAllCoroutines();
    IncreaseFiringRate();
  }
  // Increases the firing rate
  private void IncreaseFiringRate()
  {
    if (m_SpaceshipShooting != null)
      m_SpaceshipShooting.Time = m_SpaceshipShooting.MaxTime;
  }
  // Decreases the firing rate
  private void DecreaseFiringRate()
  {
    if (m_SpaceshipShooting != null)
      m_SpaceshipShooting.Time = FiringRate;
  }
}