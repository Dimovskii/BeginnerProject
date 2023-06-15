using System;
using UnityEngine;

public interface ISwitcher
{
    event Action<Transform> OnBarrelChanged;
    event Action<WeaponData> OnGunChanged;
    void Init(IInput inputWrapper);
}