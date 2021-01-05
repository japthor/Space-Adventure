using UnityEngine;

public class BulletMovementPlayerSpaceship : BulletMovement
{
  protected override void Update()
  {
    base.Update();
  }

  protected override void Movement()
  {
    transform.Translate(Vector3.up * m_Speed * Time.deltaTime);
  }
}
