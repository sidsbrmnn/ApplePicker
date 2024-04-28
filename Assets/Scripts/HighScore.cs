using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(TextMeshProUGUI))]
public class HighScore : MonoBehaviour
{
    public static HighScore Instance { get; private set; }

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
        _score = PlayerPrefs.GetInt("HighScore", 0);
        _text.text = "High Score: " + _score.ToString("#,0");
    }

    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            PlayerPrefs.SetInt("HighScore", _score);
            _text.text = "High Score: " + _score.ToString("#,0");
        }
    }
}
