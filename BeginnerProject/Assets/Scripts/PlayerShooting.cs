using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class PlayerShooting : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] private Transform _barrel;
    [SerializeField] private Transform _muzzleParent;
    [SerializeField] private WeaponConfig _weaponConfig;
    private GameObject _muzzleFlashPrefab;
    private ParticleSystem _muzzleFlash;
    private bool _isShooting = false;
    private bool _isReadyToFire = true;
    private bool _isReloading = false;
    public event Action OnFire;

    private void Awake() 
    {
        _playerInput = new PlayerInput();
        _playerInput.CharacterControls.Shooting.started += OpenFire;
        _playerInput.CharacterControls.Shooting.canceled += StopFire;
        _playerInput.CharacterControls.Reload.performed += Reloading;
    }

    private void Start() 
    {
        _muzzleFlashPrefab = _weaponConfig.MuzzleFlash;
        _muzzleFlash = _muzzleFlashPrefab.GetComponent<ParticleSystem>();  
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
           
            // _muzzleFlash.Play();
            
            _weaponConfig.CurrentAmmoCount --;
            Debug.Log(_weaponConfig.CurrentAmmoCount);

            if(_weaponConfig.CurrentAmmoCount > 0)
            {
                SetFireRate();
            }
            CreateBullet();
            OnFire?.Invoke();
        } 
    }

    private void CreateBullet()
    {
        var bullet = Instantiate(_weaponConfig.BulletType, _barrel.position, _barrel.rotation);
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

    private void SetMuzzleFlash()
    {
        Debug.Log("Flash");
        _muzzleFlash.Play();
    }

    private async void Reloading(InputAction.CallbackContext context)
    {
        Debug.Log("Reloading...");

        await Task.Delay(TimeSpan.FromSeconds(_weaponConfig.ReloadTime));
        _weaponConfig.CurrentAmmoCount = _weaponConfig.MaxAmmoCount;

        _isReloading = false;
        Debug.Log("RedyToFire!");
    }

    private void OnEnable() 
    {
        _playerInput.Enable();
        OnFire += SetMuzzleFlash;
    }

    private void OnDisable() 
    {
        _playerInput.Disable();
        OnFire -= SetMuzzleFlash;
    }
}