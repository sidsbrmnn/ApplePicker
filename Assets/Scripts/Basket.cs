using UnityEngine;

[DisallowMultipleComponent]
public class Basket : MonoBehaviour
{
    private void Update()
    {
        var mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;

        var mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        var position = transform.position;
        position.x = mousePos3D.x;
        transform.position = position;
    }

    private void OnCollisionEnter(Collision other)
    {
        var apple = other.gameObject.GetComponent<Apple>();
        if (apple)
        {
            Destroy(apple.gameObject);
            ScoreCounter.Instance.AddScore(100);
        }
    }
}
