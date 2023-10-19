using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    static private TextMeshProUGUI text;
    static private int score = 1000;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            Score = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", Score);
    }

    static public int Score
    {
        get { return score; }
        set
        {
            if (value > score)
            {
                score = value;
                if (text != null)
                {
                    text.text = "High Score: " + value.ToString("#,0");
                }
            }
        }
    }

    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScore = false;

    private void OnDrawGizmos()
    {
        if (resetHighScore)
        {
            resetHighScore = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore reset to 1,000.");
        }
    }
}
