using UnityEngine;

public class UFOMovement : SpaceObjectMovement
{
  protected override void OnEnable()
  {
    base.OnEnable();

    m_Direction = new Vector2(Random.Range(-m_DirXAngle, m_DirXAngle), -1.0f);
  }

  protected override void Update()
  {
    base.Update();
  }
}
