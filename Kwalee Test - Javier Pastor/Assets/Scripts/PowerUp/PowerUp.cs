using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
  // Reference to the Collider
  protected Collider2D m_Collider;
  // Reference to the Sprite Renderer
  protected SpriteRenderer m_SpriteRenderer;

  // Setter/Getter
  public Collider2D Collider
  {
    get { return m_Collider; }
    set { m_Collider = value; }
  }
  public SpriteRenderer SpriteRenderer
  {
    get { return m_SpriteRenderer; }
    set { m_SpriteRenderer = value; }
  }

  protected virtual void Awake()
  {
    m_Collider = GetComponent<Collider2D>();
    m_SpriteRenderer = GetComponent<SpriteRenderer>();
  }
  protected virtual void OnEnable()
  {
    GameManager.Instance.GameManagerElements.ResetEvent += Destroy;
  }
  protected virtual void OnDisable()
  {
    GameManager.Instance.GameManagerElements.ResetEvent -= Destroy;
  }
  protected virtual void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.layer == LayerMask.NameToLayer("KillSpawn"))
      Destroy(gameObject);
  }
  // Deactivates the collider and spriterenderer
  protected void Deactivate()
  {
    if (m_Collider != null)
      m_Collider.enabled = false;

    if (m_SpriteRenderer != null)
      m_SpriteRenderer.enabled = false;
  }
  // Destroy the gameobject
  protected void Destroy()
  {
    Destroy(gameObject);
  }
}
