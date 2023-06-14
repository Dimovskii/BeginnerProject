using System;

public interface IPlayerHealth
{
    event Action<int> OnHealthChanged;
    event Action OnDead;
    void Init(IInput input);
};