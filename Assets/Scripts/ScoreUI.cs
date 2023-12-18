using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textTMpro;
    void Start()
    {
        _textTMpro.text = 0.ToString();
        Score.Instance.OnScoreChanged += UpdateScoreText;
    }

    private void UpdateScoreText(int value)
    {
        _textTMpro.text = value.ToString();
    }

    private void OnDestroy()
    {
        Score.Instance.OnScoreChanged -= UpdateScoreText;
    }
}
