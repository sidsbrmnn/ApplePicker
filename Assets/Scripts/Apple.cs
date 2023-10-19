using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    private void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(gameObject);

            ApplePicker picker = Camera.main.GetComponent<ApplePicker>();
            picker.AppleMissed();
        }
    }
}
