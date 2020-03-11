using UnityEngine;

public class BulletPlayerSpaceship : Bullet
{
  protected override void Start()
  {
    base.Start();
  }

  protected override void OnBecameInvisible()
  {
    base.OnBecameInvisible();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.layer == LayerMask.NameToLayer("Asteroid") ||
        collision.gameObject.layer == LayerMask.NameToLayer("UFO"))
    {
      Deactivate();
    }
  }
}
