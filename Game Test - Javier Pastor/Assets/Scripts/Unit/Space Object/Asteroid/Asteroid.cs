using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : SpaceObject
{
  protected override void Awake()
  {
    base.Awake();
  }

  protected override void Start()
  {
    base.Start();
  }

  protected override void OnEnable()
  {
    base.OnEnable();
  }

  protected override void OnDisable()
  {
    base.OnDisable();
  }

  protected override void OnBecameInvisible()
  {
    base.OnBecameInvisible();
  }

  protected override void OnBecameVisible()
  {
    base.OnBecameVisible();
  }

  protected override void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.layer == LayerMask.NameToLayer("Kill Spawn") ||
        collision.gameObject.layer == LayerMask.NameToLayer("Spaceship") ||
        collision.gameObject.layer == LayerMask.NameToLayer("Shield"))
      Deactivate();

    if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet") && m_IsVisible)
      SubtractLife(collision.GetComponent<BulletPlayerSpaceship>().Damage);
  }
}
