using System;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanelView : Window
{
    [SerializeField] private Button _easyButton;
    [SerializeField] private Button _normalButton;
    [SerializeField] private Button _hardButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private RandomAudioButtonPlayer _player;
    
    public event Action EasyClicked;
    public event Action NormalClicked;
    public event Action HardClicked;

    private void OnEnable()
    {
        _easyButton.onClick.AddListener(Easy);
        _normalButton.onClick.AddListener(Normal);
        _hardButton.onClick.AddListener(Hard);
        _exitButton.onClick.AddListener(Exit);
    }

    private void Exit()
    {
        CloseWindow();
        _player.Play();
    }

    private void Easy()
    {
        EasyClicked?.Invoke();
        _player.Play();
    }

    private void Normal()
    {
        NormalClicked?.Invoke();
        _player.Play();
    }

    private void Hard()
    {
        HardClicked?.Invoke();
        _player.Play();
    }


    private void OnDisable()
    {
        _easyButton.onClick.RemoveListener(Easy);
        _normalButton.onClick.RemoveListener(Normal);
        _hardButton.onClick.RemoveListener(Hard);
    }
}