using System;

public interface IShoot
{
    event Action<int, int> OnShootHappened;
    void Init(IInput input, ISwitcher weaponSwitcher);
}