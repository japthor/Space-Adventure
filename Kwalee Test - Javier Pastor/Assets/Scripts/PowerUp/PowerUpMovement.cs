using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpMovement : MonoBehaviour
{
  // Speed
  [SerializeField] protected float m_Speed;
  //Setter/Getter
  public float Speed
  {
    get { return m_Speed; }
    private set { m_Speed = value; }
  }

  protected virtual void Update()
  {
    Movement();
  }

  // Movement of the powerup
  private void Movement()
  {
    transform.Translate(Vector3.down * m_Speed * Time.deltaTime);
  }
}
