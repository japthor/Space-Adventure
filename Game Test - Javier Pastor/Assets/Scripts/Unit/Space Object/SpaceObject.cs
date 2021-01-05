using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceObject : Unit
{
  // Damage that can deal the unit
  [SerializeField] protected int m_Damage;
  // Points that the unit can give.
  [SerializeField] protected int m_Points;
  // Reference to SpaceObjectPowerUpSpawner
  protected SpaceObjectPowerUpSpawner m_SpaceObjectPowerUpSpawner;
  // Checks if the object is visible.
  protected bool m_IsVisible;

  // Setter/Getters
  public int Damage
  {
    get { return m_Damage; }
    private set { m_Damage = value; }
  }
  public int Points
  {
    get { return m_Points; }
    private set { m_Points = value; }
  }
  public SpaceObjectPowerUpSpawner SpriteRenderer
  {
    get { return m_SpaceObjectPowerUpSpawner; }
    private set { m_SpaceObjectPowerUpSpawner = value; }
  }
  public bool IsVisible
  {
    get { return m_IsVisible; }
    private set { m_IsVisible = value; }
  }

  protected virtual void Awake()
  {
    m_SpaceObjectPowerUpSpawner = GetComponent<SpaceObjectPowerUpSpawner>();
  }

  protected override void Start()
  {
    base.Start();

    m_Life = m_MaxLife;
    m_InitialPosition = transform.position;
    m_IsVisible = false;
  }

  protected virtual void OnEnable()
  {
    DieEvent += KillEvent;
  }

  protected virtual void OnDisable()
  {
    DieEvent -= KillEvent;
  }

  protected virtual void OnBecameVisible()
  {
    m_IsVisible = true;
  }

  protected virtual void OnBecameInvisible()
  {
    m_IsVisible = false;
  }

  protected abstract void OnTriggerEnter2D(Collider2D collision);

  //Die logic.
  protected void KillEvent()
  {
    m_SpaceObjectPowerUpSpawner.SpawnPowerUp();
    GameManager.Instance.GameManagerElements.AddScore(m_Points);
    Deactivate();
  }
  // Deactivates the object and moves it.
  protected void Deactivate()
  {
    gameObject.SetActive(false);
    transform.position = m_InitialPosition;
  }
}
