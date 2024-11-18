using UnityEngine;

[DisallowMultipleComponent]
public class Basket : MonoBehaviour
{
    private Camera m_MainCamera;

    private void Start()
    {
        m_MainCamera = Camera.main;
    }

    private void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = -m_MainCamera.transform.position.z;

        var worldPos = m_MainCamera.ScreenToWorldPoint(mousePos);

        var position = transform.position;
        position.x = worldPos.x;
        transform.position = position;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            ScoreCounter.Instance.Add(100);
            Destroy(other.gameObject);
        }
    }
}
