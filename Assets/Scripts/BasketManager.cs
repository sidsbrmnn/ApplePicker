using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class BasketManager : MonoBehaviour
{
    public static BasketManager Instance { get; private set; }

    [SerializeField] private GameObject prefab;
    [SerializeField] private int count = 3;
    [SerializeField] private float bottomY = -14f;
    [SerializeField] private float spacing = 2f;

    private List<GameObject> _baskets;

    private void Awake()
    {
        if (Instance && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    private void Start()
    {
        _baskets = new List<GameObject>();

        for (var i = 0; i < count; i++)
        {
            var position = Vector3.zero;
            position.y = bottomY + spacing * i;
            var go = Instantiate(prefab, position, Quaternion.identity);
            _baskets.Add(go);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

    public void DestroyBasket()
    {
        var apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (var apple in apples) Destroy(apple);

        var index = _baskets.Count - 1;
        var basket = _baskets[index];
        _baskets.RemoveAt(index);
        Destroy(basket);

        if (_baskets.Count == 0) SceneManager.LoadScene("_Scene_0");
    }
}
