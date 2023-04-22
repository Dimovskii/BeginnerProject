using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private HealthSystem _playerHealth;
    private int _startHealthAmount = 100;
    private int _maxHealthAmount = 100;
    
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
        }
        else if (_playerHealth.CurrentHealth == 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        throw new NotImplementedException();
    }
}