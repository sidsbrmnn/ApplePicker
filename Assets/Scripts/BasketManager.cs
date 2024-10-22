using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class BasketManager : MonoBehaviour
{
    public static BasketManager Instance { get; private set; }

    [SerializeField] private GameObject basketPrefab;
    [SerializeField] private int count = 3;
    [SerializeField] private float bottomY = -14f;
    [SerializeField] private float spacing = 2f;

    private List<GameObject> m_Baskets;

    private void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        m_Baskets = new List<GameObject>();

        for (var i = 0; i < count; i++)
        {
            var position = new Vector3(0, bottomY + i * spacing, 0);
            var basket = Instantiate(basketPrefab, position, Quaternion.identity);
            m_Baskets.Add(basket);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void DestroyBasket()
    {
        var apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (var apple in apples)
        {
            Destroy(apple);
        }

        var index = m_Baskets.Count - 1;
        var basket = m_Baskets[index];
        m_Baskets.RemoveAt(index);
        Destroy(basket);

        if (m_Baskets.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
