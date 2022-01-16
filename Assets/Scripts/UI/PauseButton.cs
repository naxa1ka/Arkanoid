using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private bool _isPaused;

    private void OnEnable()
    {
        _button.onClick.AddListener(SwitchState);
    }

    private void SwitchState()
    {
        if (_isPaused)
        {
            TimeState.Resume();
            _isPaused = false;
        }
        else
        {
            TimeState.Stop();
            _isPaused = true;
        }
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SwitchState);
    }
}