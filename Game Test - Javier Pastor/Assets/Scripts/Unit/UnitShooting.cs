using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitShooting : MonoBehaviour
{
  // Reference to the ObjectPooling
  protected ObjectPooling m_Pool;
  // Maximum time between shots.
  [SerializeField] protected float m_MaxTime;
  // Reference to the zone where the bullets will appear.
  [SerializeField] protected GameObject m_ShootingZone;
  // Current time.
  protected float m_Time;

  // Getter/Setter
  public ObjectPooling Pool
  {
    get { return m_Pool; }
    private set { m_Pool = value; }
  }
  public float MaxTime
  {
    get { return m_MaxTime; }
    private set { m_MaxTime = value; }
  }
  public GameObject ShootingZone
  {
    get { return m_ShootingZone; }
    private set { m_ShootingZone = value; }
  }
  public float Time
  {
    get { return m_Time; }
    set { m_Time = value; }
  }

  protected virtual void Awake()
  {
    m_Pool = GetComponent<ObjectPooling>();
  }
  protected virtual void Start()
  {
    m_Time = m_MaxTime;
    StartCoroutine(SpawnCoroutine(m_Time));
  }

  // Spawn the bullet after x time passes.
  private IEnumerator SpawnCoroutine(float time)
  {
    yield return new WaitForSeconds(time);
    SpawnBullet();
  }

  // Spawn the bullet.
  private void SpawnBullet()
  {
    if (m_Pool != null)
    {
      GameObject bullet = m_Pool.GetPooledObject();

      if (bullet != null)
      {
        bullet.transform.position = m_ShootingZone.transform.position;
        bullet.SetActive(true);
      }

      StartCoroutine(SpawnCoroutine(m_Time));
    }
  }
}
