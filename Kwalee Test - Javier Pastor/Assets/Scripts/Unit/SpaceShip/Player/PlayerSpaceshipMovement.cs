using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceshipMovement : UnitMovement
{
  // Finger Touch position.
  private Vector3 m_TouchPosition;
  // Setter/Getter
  public Vector3 TouchPosition
  {
    get { return m_TouchPosition; }
    private set { m_TouchPosition = value; }
  }

  private void Start()
  {
    m_Speed = m_MaxSpeed;
  }

  protected override void Update()
  {
    base.Update();
  }

  // Moves the player from left to right on the low part of the device.
  protected override void Movement()
  {
    if (Input.touchCount > 0)
    {
      Touch touch = Input.GetTouch(0);

      if (touch.position.y < Screen.height / 5.0f)
      {
        m_TouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        m_TouchPosition.z = 0.0f;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(m_TouchPosition.x, transform.position.y),
                                                 m_Speed * Time.deltaTime);
      }
    }
  }

}
