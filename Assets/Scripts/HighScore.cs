using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(TextMeshProUGUI))]
public class HighScore : MonoBehaviour
{
    public static HighScore Instance { get; private set; }

    private const string k_HighScoreKey = "HighScore";

    private TextMeshProUGUI m_Text;
    private int m_Value;

    private void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        m_Text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        m_Value = PlayerPrefs.GetInt(k_HighScoreKey, 0);
        UpdateText();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void TrySetHighScore(int value)
    {
        if (value > m_Value)
        {
            m_Value = value;
            PlayerPrefs.SetInt(k_HighScoreKey, m_Value);
            UpdateText();
        }
    }

    private void UpdateText()
    {
        if (m_Text)
        {
            m_Text.text = $"High Score: {m_Value:#,0}";
        }
    }
}
