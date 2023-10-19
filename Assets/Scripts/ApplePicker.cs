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
    public List<GameObject> baskets;

    private void Start()
    {
        baskets = new();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject go = Instantiate(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            go.transform.position = pos;
            baskets.Add(go);
        }
    }

    public void AppleMissed()
    {
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in apples)
        {
            Destroy(apple);
        }

        int index = baskets.Count - 1;
        GameObject basket = baskets[index];
        baskets.RemoveAt(index);
        Destroy(basket);

        if (baskets.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
