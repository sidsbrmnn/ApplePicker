using UnityEngine;

[DisallowMultipleComponent]
public class AppleTree : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float leftAndRightEdge;
    [SerializeField] private float chanceToChangeDirections;

    [SerializeField] private GameObject applePrefab;
    [SerializeField] private float spawnInterval;

    private void Start()
    {
        InvokeRepeating(nameof(DropApple), 2f, spawnInterval);
    }

    private void Update()
    {
        var position = transform.position;
        position.x += speed * Time.deltaTime;
        transform.position = position;

        if (position.x < -leftAndRightEdge)
            speed = Mathf.Abs(speed);
        else if (position.x > leftAndRightEdge)
            speed = -Mathf.Abs(speed);
    }

    private void DropApple()
    {
        Instantiate(applePrefab, transform.position, Quaternion.identity);
    }
}
