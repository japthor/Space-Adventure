using UnityEngine;

public abstract class BulletMovement : MonoBehaviour
{
  // Speed of the bullet
  [SerializeField] protected float m_Speed;

  // Setters/Getters
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
