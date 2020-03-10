using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
  // Maximum life of the unit.
  [SerializeField] protected int m_MaxLife;
  // Actual life.
  protected int m_Life;
  // Initial position.
  protected Vector2 m_InitialPosition;

  // Delegate/Event for when it dies.
  public delegate void UnitDelegate();
  public event UnitDelegate DieEvent;

  // Setters/Getters
  public int MaxLife
  {
    get { return m_MaxLife; }
    private set { m_MaxLife = value; }
  }
  public int Life
  {
    get { return m_Life; }
    private set { m_Life = value; }
  }
  public Vector2 InitialPosition
  {
    get { return m_InitialPosition; }
    private set { m_InitialPosition = value; }
  }

  protected virtual void Start()
  {
    m_Life = m_MaxLife;
    m_InitialPosition = transform.position;
  }

  // Substracts the life.
  protected void SubtractLife(int value)
  {
    if ((m_Life - value) <= 0)
    {
      m_Life = 0;
      DieEvent();
    }
    else
      m_Life -= value;
  }
}
