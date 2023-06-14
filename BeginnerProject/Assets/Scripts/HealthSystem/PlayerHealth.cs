using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour, IPlayerHealth, IDamageable
{
    private HealthSystem _playerHealth;
    private int _startHealthAmount = 100;
    private int _maxHealthAmount = 100;
    private IInput _input;
    private int _healAmount = 20;

    public event Action<int> OnHealthChanged;
    public event Action OnDead;
    
    public void Init(IInput input) 
    {
        _input = input;
        _playerHealth = new HealthSystem(_startHealthAmount,_maxHealthAmount);
        Sibscribe();
    }

    private void Sibscribe()
    {
        _input.OnHealed += Heal;
    }

    private void Heal()
    {
        _playerHealth.Heal(_healAmount);
        OnHealthChanged?.Invoke(_playerHealth.CurrentHealth);
    }

    public void TakeDamage(int damage)
    {
        if(_playerHealth.CurrentHealth > 0)
        {
            _playerHealth.Damage(damage);
            OnHealthChanged?.Invoke(_playerHealth.CurrentHealth);
        }
        else if (_playerHealth.CurrentHealth == 0)
        {
            OnDead?.Invoke();

        }
    }
}