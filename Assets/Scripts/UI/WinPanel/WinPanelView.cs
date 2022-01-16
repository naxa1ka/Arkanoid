using System;
using UnityEngine;
using UnityEngine.UI;

public class WinPanelView : BasePanelView
{
    [SerializeField] private Button _nextLevel;

    public event Action NextLevelClicked;

    protected override void OnEnabled()
    {
        _nextLevel.onClick.AddListener(NextLevel);
    }

    private void NextLevel()
    {
        NextLevelClicked?.Invoke();
    }

    protected override void OnDisabled()
    {
        _nextLevel.onClick.RemoveListener(NextLevel);
    }
}