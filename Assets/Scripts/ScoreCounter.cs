using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")] public int score;

    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _text.text = score.ToString("#,0");
    }
}
