using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;

    private void Start()
    {
        InvokeRepeating(nameof(DropApple), 2f, appleDropDelay);
    }

    private void DropApple()
    {
        Instantiate(applePrefab, Pos, Quaternion.identity);
    }

    private void Update()
    {
        var pos = Pos;
        pos.x += speed * Time.deltaTime;
        Pos = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }

    private Vector3 Pos
    {
        get => transform.position;
        set => transform.position = value;
    }
}
