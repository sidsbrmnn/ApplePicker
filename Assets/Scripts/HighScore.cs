using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(TextMeshProUGUI))]
public class HighScore : MonoBehaviour
{
    public static HighScore Instance { get; private set; }

    private TextMeshProUGUI m_Text;
    private int m_Value;

    private void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        m_Text = GetComponent<TextMeshProUGUI>();
        m_Value = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Start()
    {
        UpdateText();
    }

    public void TryUpdateHighScore(int value)
    {
        if (value <= m_Value) return;

        m_Value = value;
        PlayerPrefs.SetInt("HighScore", m_Value);
        UpdateText();
    }

    private void UpdateText()
    {
        if (m_Text)
            m_Text.text = $"High Score: {m_Value:#,0}";
    }
}
