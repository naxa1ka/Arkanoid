using UnityEngine;

    public class LosePanel : BasePanel
    {
        [SerializeField] private LosePanelView _losePanelView;
        [SerializeField] private Reviver _reviver;
        [SerializeField] private Player _player;
        
        protected override void OnEnabled()
        {
            _losePanelView.ReviveClicked += OnReviveClicked;
            _player.Lose += Open;
        }
        
        private void OnReviveClicked()
        {
            Application.OpenURL("https://www.youtube.com/watch?v=fdyuOiciwB4");
            _reviver.Revive();
            _losePanelView.CloseWindow();
            TimeState.Resume();
        }

        protected override void OnDisabled()
        {
            _losePanelView.ReviveClicked -= OnReviveClicked;
            _player.Lose -= Open;
        }
    }
