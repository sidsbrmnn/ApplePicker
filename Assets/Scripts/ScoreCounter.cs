using UnityEngine;
using TMPro;

[DisallowMultipleComponent]
[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance { get; private set; }

    private TextMeshProUGUI _text;
    private int _score;

    private void Awake()
    {
        if (Instance && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        Score = 0;
    }

    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            _text.text = "Score: " + _score.ToString("#,0");

            if (_score > HighScore.Instance.Score)
                HighScore.Instance.Score = _score;
        }
    }
}
