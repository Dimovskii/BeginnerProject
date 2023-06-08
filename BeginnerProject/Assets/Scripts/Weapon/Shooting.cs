using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private WeaponData _weaponData;
    private Transform _barrel;
    private InputHandler _inputHandler;
    private WeaponSwitching _weaponSwitching;
    private bool _isFiring = false;

    private void Awake()
    {
        _inputHandler = GetComponent<InputHandler>();
        _weaponSwitching = GetComponent<WeaponSwitching>();
    }

    private void OnEnable()
    {
        _inputHandler.OnFireOpened += StartFiring;
        _inputHandler.OnFireStopped += StopFire;
        _weaponSwitching.OnWeaponDataChanged += GetWeaponData;
        _weaponSwitching.OnWeaponBarrelChanged += GetBarrelTransform;
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
    }
    
    private void OnDisable()
    {
        _inputHandler.OnFireOpened -= StartFiring;
        _inputHandler.OnFireStopped -= StopFire;
        _weaponSwitching.OnWeaponDataChanged -= GetWeaponData;
    }
}
