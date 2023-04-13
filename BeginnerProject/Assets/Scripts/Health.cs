public class Health
{
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
   
    public Health(int startHealth, int maxHealth)
    {
        CurrentHealth = startHealth;
        MaxHealth = maxHealth;
    }

    public void Damage(int damageCount)
    {
        if(CurrentHealth > 0)
            CurrentHealth -= damageCount;
        
    }

    public void Heal(int healCount)
    {
        if(CurrentHealth < MaxHealth)
            CurrentHealth += healCount;
        
        if(CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;
    }
}
