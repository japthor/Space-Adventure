using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceObjectPowerUpSpawner : MonoBehaviour
{
  // Checks if the object can spawn.
  [SerializeField] private bool m_CanSpawn;
  // List of possible powerups to spawn.
  [SerializeField] private List<PowerUp> m_PowerUps;
  // Probability to spawn a power up.
  [Range(0.0f, 100.0f)] [SerializeField] private float m_SpawnPowerUpProbability;

  // Setters/Getters
  public bool CanSpawn
  {
    get { return m_CanSpawn; }
    private set { m_CanSpawn = value; }
  }
  public List<PowerUp> PowerUps
  {
    get { return m_PowerUps; }
    private set { m_PowerUps = value; }
  }
  public float SpawnPowerUpProbability
  {
    get { return m_SpawnPowerUpProbability; }
    private set { m_SpawnPowerUpProbability = value; }
  }

  // Spawns a power up.
  public void SpawnPowerUp()
  {
    if (m_CanSpawn)
    {
      if (Spawnable())
      {
        int value = Random.Range(0, m_PowerUps.Count);
        GameObject.Instantiate(m_PowerUps[value], transform.position, Quaternion.identity);
      }
    }
  }

  // Calculates a probability to spawn
  private bool Spawnable()
  {
    float value = Random.Range(0.0f, 100.0f);

    if (value <= m_SpawnPowerUpProbability)
      return true;

    return false;
  }
}
