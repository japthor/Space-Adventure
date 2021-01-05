using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitMovement : MonoBehaviour
{
  // Maximum speed
  [SerializeField] protected float m_MaxSpeed;
  // Minimum speed
  [SerializeField] protected float m_MinSpeed;
  // Actual speed
  protected float m_Speed;

  // Setters/Getters
  public float MaxSpeed
  {
    get { return m_MaxSpeed; }
    private set { m_MaxSpeed = value; }
  }
  public float MinSpeed
  {
    get { return m_MinSpeed; }
    private set { m_MinSpeed = value; }
  }
  public float Speed
  {
    get { return m_Speed; }
    private set { m_Speed = value; }
  }

  protected virtual void Update()
  {
    Movement();
  }

  protected abstract void Movement();
}
