using UnityEngine;

public abstract class SpaceObjectMovement : UnitMovement
{
  // Random X direction to move.
  [Range(0.0f, 1.0f)] [SerializeField] protected float m_DirXAngle;
  // Direction to move.
  protected Vector2 m_Direction;

  // Setters/Getters
  public Vector2 Direction
  {
    get { return m_Direction; }
    private set { m_Direction = value; }
  }
  public float DirXAngle
  {
    get { return m_DirXAngle; }
    private set { m_DirXAngle = value; }
  }

  protected virtual void OnEnable()
  {
    m_Speed = Random.Range(m_MinSpeed, m_MaxSpeed);
  }

  protected override void Update()
  {
    base.Update();
  }

  // Moves the unit
  protected override void Movement()
  {
    transform.Translate(m_Direction * m_Speed * Time.deltaTime);
  }
}
