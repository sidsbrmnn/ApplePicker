using UnityEngine;

public class Basket : MonoBehaviour
{
    private Camera _camera;
    private ScoreCounter _counter;

    private void Start()
    {
        _camera = Camera.main;
        _counter = GameObject.Find("Score Counter").GetComponent<ScoreCounter>();
    }

    private void Update()
    {
        var mousePos2D = Input.mousePosition;
        mousePos2D.z = -_camera.transform.position.z;

        var mousePos3D =_camera.ScreenToWorldPoint(mousePos2D);

        var pos = Pos;
        pos.x = mousePos3D.x;
        Pos = pos;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Apple")) return;

        Destroy(other.gameObject);
        _counter.score += 100;
        HighScore.Score = _counter.score;
    }

    private Vector3 Pos
    {
        get => transform.position;
        set => transform.position = value;
    }
}
