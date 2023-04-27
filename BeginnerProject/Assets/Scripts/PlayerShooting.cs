using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class PlayerShooting : MonoBehaviour
{
    private PlayerInput _playerInput;
    private WeaponManager _weaponManager;
    private WeaponConfig _weaponConfig;
    private Transform _barrel;
    private ParticleSystem _muzzleFlash;
    private bool _isShooting = false;
    private bool _isReadyToFire = true;
    private bool _isReloading = false;
    public event Action<int,int> OnAmmoAmountChanged;

    private void Awake() 
    {
        _playerInput = new PlayerInput();
        _playerInput.CharacterControls.Shooting.started += OpenFire;
        _playerInput.CharacterControls.Shooting.canceled += StopFire;
        _playerInput.CharacterControls.Reload.performed += Reloading;
    }

    public void SetWeaponConfig(WeaponConfig weaponConfig)
    {
        _weaponConfig = weaponConfig;
        OnAmmoAmountChanged?.Invoke(_weaponConfig.CurrentAmmoCount, _weaponConfig.MaxAmmoCount);
    }

    public void SetBarrel(Transform barrel)
    {   
        _barrel = barrel;
    }
    
    public void SetMuzzleFlash(ParticleSystem muzzleFlash)
    {
        _muzzleFlash = muzzleFlash;
    }

    private void OpenFire(InputAction.CallbackContext context)
    {
        _isShooting = true;
        Shooting();
    }

    private void Shooting()
    {
        if(_isShooting && _isReadyToFire && !_isReloading && _weaponConfig.CurrentAmmoCount > 0)
        {
            _muzzleFlash.Play();
            
            _weaponConfig.CurrentAmmoCount--;
            OnAmmoAmountChanged?.Invoke(_weaponConfig.CurrentAmmoCount, _weaponConfig.MaxAmmoCount);

            if(_weaponConfig.CurrentAmmoCount > 0)
            {
                SetFireRate();
            }
            CreateBullet();
        } 
    }

    private void CreateBullet()
    {
        var bullet = Instantiate(_weaponConfig.BulletPrefab, _barrel.position, _barrel.rotation);
        var bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(_barrel.forward * _weaponConfig.BulletSpeed, ForceMode.Impulse);
    }

    private void StopFire(InputAction.CallbackContext context)
    {
        _isShooting = false;
    }

    private async void SetFireRate()
    {
        _isReadyToFire = false;
        
        await Task.Delay(TimeSpan.FromSeconds(_weaponConfig.FireRate));
        _isReadyToFire = true;
        Shooting();
    }

    private async void Reloading(InputAction.CallbackContext context)
    {
        await Task.Delay(TimeSpan.FromSeconds(_weaponConfig.ReloadTime));
        _weaponConfig.CurrentAmmoCount = _weaponConfig.MaxAmmoCount;

        _isReloading = false;
    }

    private void OnEnable() 
    {
        _playerInput.Enable();
    }

    private void OnDisable() 
    {
        _playerInput.Disable();
    }
}