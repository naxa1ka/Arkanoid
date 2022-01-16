using System;
using UnityEngine;
using UnityEngine.UI;

public class StartPanelView : Window
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private RandomAudioButtonPlayer _player;
    
    public event Action StartClicked;
    public event Action OptionsClicked;
    public event Action ExitClicked;
    
    private void OnEnable()
    {
        _startButton.onClick.AddListener(StartButton);
        _optionsButton.onClick.AddListener(OptionsButton);
        _exitButton.onClick.AddListener(ExitButton);
    }

    private void StartButton()
    {
        _player.Play();
        StartClicked?.Invoke();
    }

    private void OptionsButton()
    {
        _player.Play();
        OptionsClicked?.Invoke();
    }

    private void ExitButton()
    {
        _player.Play();
        ExitClicked?.Invoke();
    }


    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(StartButton);
        _optionsButton.onClick.RemoveListener(OptionsButton);
        _exitButton.onClick.RemoveListener(ExitButton);
    }
}