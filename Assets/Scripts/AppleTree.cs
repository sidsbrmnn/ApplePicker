using UnityEngine;

[DisallowMultipleComponent]
public class AppleTree : MonoBehaviour
{
    [Header("Apple Tree Settings")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private Vector2 bounds = new(-24f, 24f);
    [SerializeField] private float changeDirectionChance = 0.1f;

    [Header("Apple Spawner Settings")]
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private float spawnDelay = 1f;

    private void Start()
    {
        InvokeRepeating(nameof(DropApple), 2f, spawnDelay);
    }

    private void Update()
    {
        var position = Position;
        position.x += speed * Time.deltaTime;
        Position = position;

        if (position.x < bounds.x) speed = Mathf.Abs(speed);
        else if (position.x > bounds.y) speed = -Mathf.Abs(speed);
    }

    private void FixedUpdate()
    {
        if (Random.value < changeDirectionChance) speed *= -1;
    }

    private void DropApple()
    {
        Instantiate(applePrefab, Position, Quaternion.identity);
    }

    private Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
    }
}
