using System;
using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    private ScoreHandler _scoreHandler;

    [Inject]
    private void Constructor(ScoreHandler scoreHandler)
    {
        _scoreHandler = scoreHandler;
    }
    
    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        UpdateText(_scoreHandler.Score);
    }

    private void OnEnable()
    {
        _scoreHandler.ScoreChanged += UpdateText;
    }

    private void UpdateText(int score)
    {
        _textMeshPro.text = score.ToString();
    }

    private void OnDisable()
    {
        _scoreHandler.ScoreChanged -= UpdateText;
    }
}
