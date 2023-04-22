using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    private HealthSystem _health;
    private int _startHealthAmount = 100;
    private int _maxHealthAmount = 100;

    private void Awake() 
    {
        _health = new HealthSystem(_startHealthAmount, _maxHealthAmount);
    }

    public void TakeDamage(int damage)
    {
        if(_health.CurrentHealth > 0)
        {
            _health.Damage(damage);
        }
        else if(_health.CurrentHealth <= 0)
        {
            Death();
        }
    }
   
    private void Death()
    {
        Destroy(gameObject);
    }
}
