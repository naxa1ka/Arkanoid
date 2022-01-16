using System;
using UnityEngine;

public class Player : MonoBehaviour, IHealth
{
    [SerializeField] private Ball _ball;

    private const int InitHealth = 1;

    private int _currentHealth = InitHealth;
    private int Health
    {
        set
        {
            _currentHealth = value;
            HealthChanged?.Invoke(_currentHealth);
        }
        get => _currentHealth;
    }

    public event Action<int> HealthChanged;
    public event Action Lose;

    public void Revive()
    {
        Health++;
    }
    
    private void OnEnable()
    {
        _ball.Died += OnDied;
    }

    private void OnDied()
    {
        Health--;

        if (_currentHealth == 0)
        {
            Lose?.Invoke();
        }
    }

    private void OnDisable()
    {
        _ball.Died -= OnDied;
    }
}