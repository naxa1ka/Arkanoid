using System;
using UnityEngine;
using UnityEngine.UI;

public class LosePanelView : BasePanelView
{
    [SerializeField] private Button _reviveButton;

    public event Action ReviveClicked;

    protected override void OnEnabled()
    {
        _reviveButton.onClick.AddListener(Revive);
    }

    private void Revive()
    {
        ReviveClicked?.Invoke();
    }

    protected override void OnDisabled()
    {
        _reviveButton.onClick.RemoveListener(Revive);
    }
}