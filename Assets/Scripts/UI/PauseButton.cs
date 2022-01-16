using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private RandomAudioButtonPlayer _player;
    
    private bool _isPaused;

    private void OnEnable()
    {
        _button.onClick.AddListener(SwitchState);
    }

    private void SwitchState()
    {
        _player.Play();
        
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