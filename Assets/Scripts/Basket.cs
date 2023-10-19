using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter counter;

    private void Start()
    {
        GameObject go = GameObject.Find("ScoreCounter");
        counter = go.GetComponent<ScoreCounter>();
    }

    private void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);

            counter.score += 100;
            HighScore.Score = counter.score;
        }
    }
}
