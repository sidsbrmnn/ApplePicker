using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;

    private List<GameObject> _baskets;

    private void Start()
    {
        _baskets = new List<GameObject>();

        for (var i = 0; i < numBaskets; i++)
        {
            var pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            var basket = Instantiate(basketPrefab, pos, Quaternion.identity);
            _baskets.Add(basket);
        }
    }

    public void DestroyAllApples()
    {
        var apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (var apple in apples)
        {
            Destroy(apple);
        }

        var indexToRemove = _baskets.Count - 1;
        var basket = _baskets[indexToRemove];
        _baskets.RemoveAt(indexToRemove);
        Destroy(basket);

        if (_baskets.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
