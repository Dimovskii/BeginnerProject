using System;
using System.Collections;
using UnityEngine;

namespace Weapon
{
    public class Reload : MonoBehaviour, IReload
    {
        private IInput _input;
        private ISwitcher _weaponSwitcher;
        private WeaponData _weaponData;
        private bool _isReloading = false;
        public event Action<int, int> OnReloaded;
        public void Init(IInput input, ISwitcher weaponSwitcher)
        {
            _input = input;
            _weaponSwitcher = weaponSwitcher;
            Subscribe();
        }

        private void Subscribe()
        {
            _weaponSwitcher.OnGunChanged += GetWeaponData;
            _input.OnReloaded += StartReloading;
        }

        private void GetWeaponData(WeaponData data)
        {
            _weaponData = data;
        }

        private void StartReloading()
        {
            _isReloading = true;
            StartCoroutine(Reloading());
        }

        IEnumerator Reloading()
        {
            while (_isReloading)
            {
                yield return new WaitForSeconds(_weaponData.ReloadTime);
                _weaponData.CurrentAmmoCount = _weaponData.MaxAmmoCount;
                _isReloading = false;
                OnReloaded?.Invoke(_weaponData.CurrentAmmoCount, _weaponData.MaxAmmoCount);
            }
        }

        private void OnDisable()
        {
            _weaponSwitcher.OnGunChanged -= GetWeaponData;
            _input.OnReloaded -= StartReloading;
        }
    }
}