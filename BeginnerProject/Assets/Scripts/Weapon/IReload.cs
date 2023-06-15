using System;

namespace Weapon
{
    public interface IReload
    {
        event Action<int, int> OnReloaded;
        void Init(IInput input, ISwitcher weaponSwitcher);
    }
}