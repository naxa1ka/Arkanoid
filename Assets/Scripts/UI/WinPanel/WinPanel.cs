using UnityEngine;

public class WinPanel : BasePanel
{
    [SerializeField] private WinPanelView _winPanelView;
    [SerializeField] private PlatformHandler _platformHandler;
    
    protected override void OnEnabled()
    {
        _winPanelView.NextLevelClicked += OnNextLevelClicked;
        _platformHandler.PlatformsEnded += Open;
    }
    
    private void OnNextLevelClicked()
    {
        SceneChanger.ReloadWithProgress();
    }

    protected override void OnDisabled()
    {
        _winPanelView.NextLevelClicked -= Open;
    }
}