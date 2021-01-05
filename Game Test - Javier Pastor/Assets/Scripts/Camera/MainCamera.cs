using UnityEngine;

public class MainCamera : MonoBehaviour
{
  // Camera Bounds
  private Vector2 m_ScreenBounds;
  // Setters/Getters
  public Vector2 ScreenBounds
  {
    get { return m_ScreenBounds; }
    private set { m_ScreenBounds = value; }
  }

  private void Start()
  {
    m_ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
  }
}
