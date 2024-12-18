using UnityEngine;

[DisallowMultipleComponent]
public class Apple : MonoBehaviour
{
    [SerializeField] private float bottomY;

    private void Update()
    {
        if (transform.position.y < bottomY)
        {
            BasketManager.Instance.DestroyBasket();
            Destroy(gameObject);
        }
    }
}
