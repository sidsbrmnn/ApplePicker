using UnityEngine;

public class Apple : MonoBehaviour
{
    private Camera _camera;
    private const float BottomY = -20f;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (transform.position.y >= BottomY) return;

        Destroy(gameObject);

        var applePicker = _camera.GetComponent<ApplePicker>();
        applePicker.DestroyAllApples();
    }
}
