
    using System;
    using UnityEngine;
    using Zenject;

    public class StartPanel : MonoBehaviour
    {
        [SerializeField] private StartPanelView _startPanelView;
        [SerializeField] private OptionsPanelView _optionsPanel;
        
        private SceneChanger _sceneChanger;

        [Inject]
        private void Constructor(SceneChanger sceneChanger)
        {
            _sceneChanger = sceneChanger;
        }
        
        private void OnEnable()
        {
            _startPanelView.ExitClicked += OnExitClicked;
            _startPanelView.OptionsClicked += OnOptionsClicked;
            _startPanelView.StartClicked += OnStartClicked;
        }

        private void OnStartClicked()
        {
            _sceneChanger.LoadGame();
        }

        private void OnOptionsClicked()
        {
            _optionsPanel.OpenWindow();
        }

        private void OnExitClicked()
        {
            Application.Quit();
        }
        
        private void OnDisable()
        {
            _startPanelView.ExitClicked -= OnExitClicked;
            _startPanelView.OptionsClicked -= OnOptionsClicked;
            _startPanelView.StartClicked -= OnStartClicked;
        }
    }
