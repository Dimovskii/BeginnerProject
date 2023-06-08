using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private HealthSystem _playerHealth;
    private int _startHealthAmount = 100;
    private int _maxHealthAmount = 100;
    public event Action<int> OnHealthChanged;
    public event Action OnDead;
    
    private void Awake() 
    {
        _playerHealth = new HealthSystem(_startHealthAmount,_maxHealthAmount);
    }

    private void Heal(int healing)
    {
        _playerHealth.Heal(healing);
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