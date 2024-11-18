using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance { get; private set; }

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
    }

    private void Start()
    {
        UpdateText();
    }

    public void Add(int value)
    {
        m_Value += value;
        HighScore.Instance.TryUpdateHighScore(m_Value);
        UpdateText();
    }

    private void UpdateText()
    {
        if (m_Text)
            m_Text.text = $"{m_Value:#,0}";
    }
}
