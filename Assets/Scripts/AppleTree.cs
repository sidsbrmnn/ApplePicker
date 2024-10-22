using UnityEngine;

[DisallowMultipleComponent]
public class AppleTree : MonoBehaviour
{
    [Header("Apple Tree Settings")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float leftAndRightEdge = 24f;
    [SerializeField] private float changeDirectionChange = 0.1f;

    [Header("Apple Drop Settings")]
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private float spawnDelay = 1f;

    private void Start()
    {
        InvokeRepeating(nameof(DropApple), 2f, spawnDelay);
    }

    private void Update()
    {
        var position = transform.position;
        position.x += speed * Time.deltaTime;
        transform.position = position;

        if (position.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (position.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < changeDirectionChange)
        {
            speed *= -1;
        }
    }

    private void DropApple()
    {
        Instantiate(applePrefab, transform.position, Quaternion.identity);
    }
}
