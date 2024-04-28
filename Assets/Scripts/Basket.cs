using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class Basket : MonoBehaviour
{
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        var mousePosition = Input.mousePosition;
        mousePosition.z = -_mainCamera.transform.position.z;

        var worldPoint = _mainCamera.ScreenToWorldPoint(mousePosition);

        var position = Position;
        position.x = worldPoint.x;
        Position = position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
            ScoreCounter.Instance.Score += 100;
        }
    }

    private Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
    }
}
