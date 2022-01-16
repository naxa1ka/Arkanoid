using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BasePanelView : Window
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [Space]
    [SerializeField] private Button _replayButton;
    [SerializeField] private Button _mainMenuButton;

    public event Action ReplayClicked;
    public event Action MainMenuClicked;

    public void Open(int score)
    {
        OpenWindow();
        _scoreText.text = score.ToString();
    }

    private void OnEnable()
    {
        _replayButton.onClick.AddListener(Replay);
        _mainMenuButton.onClick.AddListener(MainMenu);
        OnEnabled();
    }

    protected abstract void OnEnabled();
    
    private void Replay()
    {
        ReplayClicked?.Invoke();
    }

    private void MainMenu()
    {
        MainMenuClicked?.Invoke();
    }
    

    private void OnDisable()
    {
        _replayButton.onClick.RemoveListener(Replay);
        _mainMenuButton.onClick.RemoveListener(MainMenu);
        OnDisabled();
    }
    
    protected abstract void OnDisabled();
}