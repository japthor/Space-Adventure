using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : Unit
{
  // Reference to SpriteRenderer.
  private SpriteRenderer m_SpriteRenderer;
  // Width of the spaceship.
  private float m_Width;
  // Height of the spaceship.
  private float m_Height;
  // Boundaries.
  private Vector2 m_Bounds;
  // Reference to the Maincamera script.
  private MainCamera m_MainCamera;

  // Delegate/Event for updating the life.
  public delegate void UIDelegate();
  public event UIDelegate LifeEvent;

  // Setter/Getter
  public SpriteRenderer SpriteRenderer
  {
    get { return m_SpriteRenderer; }
    private set { m_SpriteRenderer = value; }
  }
  public float Width
  {
    get { return m_Width; }
    private set { m_Width = value; }
  }
  public float Height
  {
    get { return m_Height; }
    private set { m_Height = value; }
  }
  public Vector2 Bounds
  {
    get { return m_Bounds; }
    private set { m_Bounds = value; }
  }

  private void Awake()
  {
    m_SpriteRenderer = GetComponent<SpriteRenderer>();
    m_MainCamera = Camera.main.GetComponent<MainCamera>();
  }

  private void OnEnable()
  {
    DieEvent += KillEvent;
  }

  private void OnDisable()
  {
    DieEvent -= KillEvent;
  }

  protected override void Start()
  {
    base.Start();

    m_Width = SpriteRenderer.bounds.size.x / 2;
    m_Height = SpriteRenderer.bounds.size.y / 2;

    Bounds = new Vector2(m_MainCamera.ScreenBounds.x - m_Width,
                         m_MainCamera.ScreenBounds.y - m_Height);
    LifeEvent();
  }

  // Damages the unit 
  protected void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.layer == LayerMask.NameToLayer("Asteroid") ||
       collision.gameObject.layer == LayerMask.NameToLayer("UFO"))
    {
      SubtractLife(collision.GetComponent<SpaceObject>().Damage);
      transform.position = InitialPosition;
      LifeEvent();
      GameManager.Instance.GameManagerElements.FireResetEvent();
    }
  }

  private void KillEvent()
  {
    gameObject.SetActive(false);
    GameManager.Instance.GameManagerElements.FireLoseEvent();
  }
}
