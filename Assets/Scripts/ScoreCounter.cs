using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance { get; private set; }

    public int Value { get; private set; }

    private TextMeshProUGUI m_Text;

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
        Value = 0;
        UpdateText();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void AddScore(int value)
    {
        Value += value;
        HighScore.Instance.TrySetHighScore(Value);
        UpdateText();
    }

    private void UpdateText()
    {
        if (m_Text)
        {
            m_Text.text = $"{Value:#,0}";
        }
    }
}
