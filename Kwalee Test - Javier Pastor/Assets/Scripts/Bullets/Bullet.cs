using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
  // Initial Position.
  private Vector2 m_OriginalPosition;
  // Damage that the bullet can deal
  [SerializeField] protected int m_Damage;

  // Setters/Getters
  public Vector2 OriginalPosition
  {
    get { return m_OriginalPosition; }
    private set { m_OriginalPosition = value; }
  }
  public int Damage
  {
    get { return m_Damage; }
    private set { m_Damage = value; }
  }

  protected virtual void Start()
  {
    m_OriginalPosition = transform.position;
  }
  protected virtual void OnBecameInvisible()
  {
    Deactivate();
  }
  
  // Deactivates the objects and moves the position.
  protected void Deactivate()
  {
    gameObject.SetActive(false);
    transform.position = m_OriginalPosition;
  }
}
