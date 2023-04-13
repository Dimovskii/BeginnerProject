using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public Health _playerHealth;
    private  int _damageAmount;
    private const int _healAmount = 20;
    private int _startHealthAmount = 100;
    private int _maxHealthAmount = 100;
    public event Action<int> OnHealed;
    public event Action OnDead;
    [SerializeField] GameOverScreen _gamerOverScreen;
    
    private void Awake() 
    {
        _playerHealth = new Health(_startHealthAmount,_maxHealthAmount);
    }

    private void Update()   
    {
        HealthChange();
        Debug.Log($"PlayerHealth" + _playerHealth.CurrentHealth);

    }
    private void HealthChange()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {   
            OnHealed?.Invoke(_healAmount);
            Debug.Log(_playerHealth.CurrentHealth);
        }
    }

    private void Heal(int healing)
    {
        _playerHealth.Heal(healing);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(_playerHealth.CurrentHealth);
        if(_playerHealth.CurrentHealth > 0)
            _playerHealth.Damage(damage);
        else
            OnDead?.Invoke();

    }

    private void OnEnable() 
    {
        OnHealed += Heal;
        OnDead += _gamerOverScreen.ShowGameOverScreen;
    }
    private void OnDisable() 
    {
        OnHealed -= Heal;
        OnDead -= _gamerOverScreen.ShowGameOverScreen;
    }
}