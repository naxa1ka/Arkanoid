using UnityEngine;
    using Zenject;

    public class OptionsPanel : MonoBehaviour
    {
        [SerializeField] private OptionsPanelView _optionsPanelView;
        
        private SceneChanger _sceneChanger;

        [Inject]
        private void Constructor(SceneChanger sceneChanger)
        {
            _sceneChanger = sceneChanger;
        }
        
        private void OnEnable()
        {
            _optionsPanelView.EasyClicked += OnEasyClicked;
            _optionsPanelView.NormalClicked += OnNormalClicked;
            _optionsPanelView.HardClicked += OnHardClicked;
        }

        private void OnEasyClicked()
        {
            SetDifficulty(DifficultyEnum.Easy);
        }

        private void OnNormalClicked()
        {
            SetDifficulty(DifficultyEnum.Normal);
        }

        private void OnHardClicked()
        {
            SetDifficulty(DifficultyEnum.Hard);
        }

        private void SetDifficulty(DifficultyEnum difficultyEnum)
        {
            _sceneChanger.SetDifficulty(difficultyEnum);
        }
        
        private void OnDisable()
        {
            _optionsPanelView.EasyClicked -= OnEasyClicked;
            _optionsPanelView.NormalClicked -= OnNormalClicked;
            _optionsPanelView.HardClicked -= OnHardClicked;
        }
    }
