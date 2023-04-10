using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{ [SerializeField] private List<Transform> _weaponsTransform;
    [SerializeField] private List<WeaponConfig> _weaponsConfig;
    [SerializeField] private List<Transform> _barrels;
    [SerializeField] private List<ParticleSystem> _muzzleFlash;
    [SerializeField] private PlayerShooting _playerShooting;
    private const string _mouseScroll = "Mouse ScrollWheel";
    private WeaponConfig _currentWeaponConfig;
    private Transform _currentBarrel;
    private ParticleSystem _currentMuzzleFlash;

    private int _idCurrentWeapon = 0;
    private int _idCurrentWeaponConfig;
    private int _idCurrentBarrel;
    private int _idCurrentMuzzleFlash;

    private void Awake() 
    {
        SelectWeapon();
    }

    private void Update() 
    {
        Switch();
        SetWeaponConfig();
        SetBarrel();
        SetMuzzleFlash();

    }

    private void Switch()
    {
        int idPreviousWeapon = _idCurrentWeapon;

        if (Input.GetAxis(_mouseScroll) > 0f)
        {
            if (_idCurrentWeapon >= transform.childCount -1)
                _idCurrentWeapon = 0;
            else 
                _idCurrentWeapon ++;
        }
        
        if (Input.GetAxis(_mouseScroll) < 0f)
        {
            if (_idCurrentWeapon <= 0)
                _idCurrentWeapon = transform.childCount -1;
            else 
                _idCurrentWeapon --; 
        }

        if (idPreviousWeapon != _idCurrentWeapon)
        {
            SelectWeapon();
        }
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == _idCurrentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
                weapon.gameObject.SetActive(false);
            i++; 
        }
    }

    private void SetWeaponConfig()
    {
        _idCurrentWeaponConfig = _idCurrentWeapon;
        _currentWeaponConfig = _weaponsConfig[_idCurrentWeaponConfig];
        _playerShooting.SetWeaponConfig(_currentWeaponConfig);
    }
    private void SetBarrel()
    {
        _idCurrentBarrel = _idCurrentWeapon;
        _currentBarrel = _barrels[_idCurrentBarrel];
        _playerShooting.SetBarrel(_currentBarrel);
    }
    private void SetMuzzleFlash()
    {
        _idCurrentMuzzleFlash = _idCurrentWeapon;
        _currentMuzzleFlash = _muzzleFlash[_idCurrentMuzzleFlash];
        _playerShooting.SetMuzzleFlash(_currentMuzzleFlash);
    }
}
