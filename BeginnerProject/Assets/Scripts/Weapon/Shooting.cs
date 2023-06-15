using System;
using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour, IShoot
{
    private WeaponData _weaponData;
    private Transform _barrel;
    private bool _isFiring = false;
    private ISwitcher _weaponSwitcher;
    private IInput _input;
    public event Action<int, int> OnShootHappened;

    public void Init(IInput input, ISwitcher weaponSwitcher)
    {
        _input = input;
        _weaponSwitcher = weaponSwitcher;
        Discribe();
    }

    private void Discribe()
    {
        _weaponSwitcher.OnBarrelChanged += GetBarrelTransform;
        _weaponSwitcher.OnGunChanged += GetWeaponData;
        _input.OnFireOpened += StartFiring;
        _input.OnFireStopped += StopFire;
    }

    private void GetWeaponData(WeaponData data)
    {
        _weaponData = data;
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
            yield return new WaitForSeconds(_weaponData.FireRate);
        }
    }

    private void CreateBullet()
    {
        var bullet = Instantiate(_weaponData.BulletPrefab, _barrel.position, _barrel.rotation);
        bullet.GetComponent<BulletController>().Init(_weaponData.BulletSpeed, _weaponData.Damage);
        OnShootHappened?.Invoke(_weaponData.CurrentAmmoCount, _weaponData.MaxAmmoCount);
    }
    
    private void OnDisable()
    {
        _input.OnFireOpened -= StartFiring;
        _input.OnFireStopped -= StopFire;
        _weaponSwitcher.OnGunChanged -= GetWeaponData;
    }
}
