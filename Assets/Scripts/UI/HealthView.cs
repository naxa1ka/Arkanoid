using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _health;
    [SerializeField] private Image[] _hearts;

    private IHealth Health => (IHealth)_health;

    private void OnValidate()
    {
        if (_health is IHealth)
            return;

        Debug.LogError(_health.name + " needs to implement " + nameof(IHealth));
        _health = null;
    }

    private void OnEnable()
    {
        Health.HealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(int currentHealth)
    {
        foreach (var heart in _hearts)
        {
            heart.gameObject.SetActive(false);
        }

        for (var i = 0; i < currentHealth; i++)
        {
            _hearts[i].gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        Health.HealthChanged -= OnHealthChanged;
    }
}