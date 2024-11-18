using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class BasketManager : MonoBehaviour
{
    public static BasketManager Instance { get; private set; }

    [SerializeField] private GameObject basketPrefab;
    [SerializeField] private float bottomY;
    [SerializeField] private float spacing;
    [SerializeField] private int basketCount;

    private List<GameObject> m_Baskets;

    private void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        m_Baskets = new List<GameObject>();

        for (var i = 0; i < basketCount; i++)
        {
            var position = new Vector3(0, bottomY + i * spacing, 0);
            var go = Instantiate(basketPrefab, position, Quaternion.identity);
            m_Baskets.Add(go);
        }
    }

    public void DestroyBasket()
    {
        var apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (var apple in apples)
            Destroy(apple);

        var idx = m_Baskets.Count - 1;
        var go = m_Baskets[idx];
        m_Baskets.RemoveAt(idx);
        Destroy(go);

        if (m_Baskets.Count == 0)
            SceneManager.LoadScene(0);
    }
}
