using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Reload : MonoBehaviour
    {
        private InputHandler _inputHandler;
        private WeaponSwitching _weaponSwitching;
        private WeaponData _weaponData;
        private bool _isReloading = false;

        private void Awake()
        {
            _inputHandler = GetComponent<InputHandler>();
            _weaponSwitching = GetComponent<WeaponSwitching>();
        }

        private void OnEnable()
        {
            _weaponSwitching.OnWeaponDataChanged += GetWeaponData;
            _inputHandler.OnReloaded += StartReloading;
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
            }
        }

        private void OnDisable()
        {
            _weaponSwitching.OnWeaponDataChanged -= GetWeaponData;
            _inputHandler.OnReloaded -= StartReloading;
        }
    }
}