using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
  // List of prefabs.
  [SerializeField] private List<GameObject> m_Prefab;
  // List of pooled objects.
  private List<GameObject> m_PooledObjects;
  // Quantity of pooled objects.
  [SerializeField] private int m_MaxPools;

  // Setters/Getters
  public List<GameObject> Prefab
  {
    get { return m_Prefab; }
    private set { m_Prefab = value; }
  }
  public List<GameObject> PooledObjects
  {
    get { return m_PooledObjects; }
    private set { m_PooledObjects = value; }
  }
  public int MaxPools
  {
    get { return m_MaxPools; }
    private set { m_MaxPools = value; }
  }

  private void Awake()
  {
    m_PooledObjects = new List<GameObject>();
    InitiatePool();
  }

  private void OnEnable()
  {
    GameManager.Instance.GameManagerElements.ResetEvent += DeactivateAll;
  }
  private void OnDisable()
  {
    GameManager.Instance.GameManagerElements.ResetEvent -= DeactivateAll;
  }

  // Initialize the pooled list.
  private void InitiatePool()
  {
    for (int i = 0; i < m_MaxPools; i++)
    {
      GameObject obj = Instantiate(m_Prefab[Random.Range(0, m_Prefab.Count - 1)]);

      obj.SetActive(false);
      m_PooledObjects.Add(obj);
    }
  }


  // Gets a pooled object.
  public GameObject GetPooledObject()
  {
    for(int i = 0; i< m_PooledObjects.Count; i++)
    {
      if (!m_PooledObjects[i].activeInHierarchy)
        return m_PooledObjects[i];
    }

    return null;
  }

  // Deactivates all the pooled objects.
  private void DeactivateAll()
  {
    for (int i = 0; i < m_PooledObjects.Count; i++)
    {
      if(m_PooledObjects[i].activeSelf)
        m_PooledObjects[i].SetActive(false);
    }
  }
}
