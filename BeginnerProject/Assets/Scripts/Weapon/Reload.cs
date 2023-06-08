using InputSystem;
using Interfaces;
using System;
using System.Collections;
using UnityEngine;

namespace Weapon
{
    public class Reload : MonoBehaviour, IAmmoCounter
    {
        private InputWrapper _inputWraper;
        private WeaponSwitcher _weaponSwitching;
        private WeaponData _weaponData;
        private bool _isReloading = false;
        public event Action<int, int> OnAmmoChanged;

        private void Awake()
        {
            _inputWraper = GetComponent<InputWrapper>();
            _weaponSwitching = GetComponent<WeaponSwitcher>();
        }

        private void OnEnable()
        {
            _weaponSwitching.OnWeaponChanged += GetWeaponData;
            _inputWraper.OnReloaded += StartReloading;
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
                OnAmmoChanged?.Invoke(_weaponData.CurrentAmmoCount, _weaponData.MaxAmmoCount);
                _isReloading = false;
            }
        }

        private void OnDisable()
        {
            _weaponSwitching.OnWeaponChanged -= GetWeaponData;
            _inputWraper.OnReloaded -= StartReloading;
        }
    }
}