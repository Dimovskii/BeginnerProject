using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] private GunData _gunData;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private float _bulletSpeed = 50f;
    private bool _isShooting;
    private bool _isReadyToFire = true;
    private const string _prepareShoot = "PrepareShoot";
    private const string _reloadAmmo = "ReloadAmmo";

    private void Awake() 
    {
        _playerInput = new PlayerInput();    
        _playerInput.CharacterControls.Shooting.started += _ => OpenFire();
        _playerInput.CharacterControls.Shooting.canceled += _ => CeaseFire();
        _playerInput.CharacterControls.Reload.performed += _ => PrepareReloadAmmo();
    }

    private void Update() 
    {
        if(_isShooting && _isReadyToFire && _gunData.CurrentAmmo > 0)
        {
            Shoot();
        }    
    }

    private void OpenFire()
    {
        _isShooting = true;
    }

    private void CeaseFire()
    {
        _isShooting = false;
    }

    private void Shoot() 
    {
        _muzzleFlash.Play();
        _isReadyToFire = false;
        var bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation );
        var bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(_bulletSpawnPoint.forward * _bulletSpeed, ForceMode.Impulse);
        
        _gunData.CurrentAmmo--;
        Debug.Log(_gunData.CurrentAmmo);
        
        if(_gunData.CurrentAmmo >= 0)
        {
            Invoke(_prepareShoot, _gunData.FareRate);
        }
    }

    private void PrepareShoot()
    {
        _isReadyToFire = true;
    }

    private void PrepareReloadAmmo()
    {
        Debug.Log("Reloading...");
        Invoke(_reloadAmmo, _gunData.ReloadTime);
    }

    private void ReloadAmmo()
    {
        _gunData.CurrentAmmo = _gunData.MaxAmmoCount;
        Debug.Log("ReadyToFire");
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