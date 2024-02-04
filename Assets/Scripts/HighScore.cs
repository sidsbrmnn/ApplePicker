using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private static TextMeshProUGUI _text;
    private static int _score = 1000;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            Score = PlayerPrefs.GetInt("HighScore");
        }

        UpdatePrefsAndUI();
    }

    private static void UpdatePrefsAndUI()
    {
        PlayerPrefs.SetInt("HighScore", Score);
        if (_text != null)
        {
            _text.text = "High Score: " + Score.ToString("#,0");
        }
    }

    public static int Score
    {
        get => _score;
        set
        {
            if (value <= _score) return;
            _score = value;
            UpdatePrefsAndUI();
        }
    }

    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScore;

    private void OnDrawGizmos()
    {
        if (!resetHighScore) return;

        resetHighScore = false;
        PlayerPrefs.SetInt("HighScore", 1000);
        Debug.LogWarning("PlayerPrefs HighScore reset to 1,000.");
    }
}
