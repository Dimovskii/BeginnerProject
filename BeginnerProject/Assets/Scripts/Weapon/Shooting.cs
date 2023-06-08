using InputSystem;
using Interfaces;
using System;
using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour, IAmmoCounter
{
    private WeaponData _weaponData;
    private Transform _barrel;
    private InputWrapper _inputWraper;
    private WeaponSwitcher _weaponSwitching;
    private bool _isFiring = false;
    public event Action<int, int> OnAmmoChanged;

    private void Awake()
    {
        _inputWraper = GetComponent<InputWrapper>();
        _weaponSwitching = GetComponent<WeaponSwitcher>();
    }

    private void OnEnable()
    {
        _inputWraper.OnFireOpened += StartFiring;
        _inputWraper.OnFireStopped += StopFire;
        _weaponSwitching.OnWeaponChanged += GetWeaponData;
        _weaponSwitching.OnBarrelChanged += GetBarrelTransform;
    }

    private void GetWeaponData(WeaponData data)
    {
        _weaponData = data;
        OnAmmoChanged?.Invoke(_weaponData.CurrentAmmoCount, _weaponData.MaxAmmoCount);
    }

    private void GetBarrelTransform(Transform barrel)
    {
        _barrel = barrel;
    }

    private void StartFiring()
    {
        StartCoroutine(GunFire());
    }

    private void StopFire() => _isFiring = false;

    IEnumerator GunFire()
    {
        _isFiring = true;

        while (_isFiring && _weaponData.CurrentAmmoCount > 0)
        {
            _barrel.GetComponentInChildren<ParticleSystem>().Play();
            CreateBullet();

            _weaponData.CurrentAmmoCount--;
            OnAmmoChanged?.Invoke(_weaponData.CurrentAmmoCount, _weaponData.MaxAmmoCount);
            yield return new WaitForSeconds(_weaponData.FireRate);
        }
    }

    private void CreateBullet()
    {
        var bullet = Instantiate(_weaponData.BulletPrefab, _barrel.position, _barrel.rotation);
        bullet.GetComponent<BulletController>().Init(_weaponData.BulletSpeed, _weaponData.Damage);
    }
    
    private void OnDisable()
    {
        _inputWraper.OnFireOpened -= StartFiring;
        _inputWraper.OnFireStopped -= StopFire;
        _weaponSwitching.OnWeaponChanged -= GetWeaponData;
    }
}
