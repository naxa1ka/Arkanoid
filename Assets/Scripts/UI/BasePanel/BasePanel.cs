using UnityEngine;
using Zenject;

public abstract class BasePanel : MonoBehaviour
{
    [SerializeField] private BasePanelView _basePanel;

    private ScoreHandler _scoreHandler;
    protected SceneChanger SceneChanger;

    [Inject]
    private void Constructor(SceneChanger sceneChanger)
    {
        SceneChanger = sceneChanger;
    }
    
    protected void Open()
    {
        TimeState.Stop();
        _basePanel.Open(_scoreHandler.Score);
    }
    
    [Inject]
    private void Constructor(ScoreHandler scoreHandler)
    {
        _scoreHandler = scoreHandler;
    }
    
    private void OnEnable()
    {
        _basePanel.ReplayClicked += OnReplayClicked;
        _basePanel.MainMenuClicked += OnMainMenuClicked;

        OnEnabled();
    }
    
    protected abstract void OnEnabled();

    private void OnMainMenuClicked()
    {
        SceneChanger.LoadMenu();
    }

    private void OnReplayClicked()
    {
        SceneChanger.LoadGame();
    }
    
    private void OnDisable()
    {
        _basePanel.ReplayClicked -= OnReplayClicked;
        _basePanel.MainMenuClicked -= OnMainMenuClicked;

        OnDisabled();
    }
    
    protected abstract void OnDisabled();
}