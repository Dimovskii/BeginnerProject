using UnityEngine;
using System.Collections.Generic;
using System;
using InputSystem;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private List<Transform> _weaponsTransform;
    [SerializeField] private List<Transform> _barrelsTransform;
    [SerializeField] private List<WeaponData> _weaponsData;
    private InputWrapper _inputWrapper;
    public event Action<WeaponData> OnWeaponChanged;
    public event Action<Transform> OnBarrelChanged;

    private void Awake()
    {
        _inputWrapper = GetComponent<InputWrapper>();
    }

    private void OnEnable()
    {
        _inputWrapper.OnWeaponChanged += SetWeapon;
        _inputWrapper.OnWeaponChanged += SetWeaponData;
        _inputWrapper.OnWeaponChanged += SetBarrerTransform;
    }

    private void SetWeapon(WeaponsType weaponsType)
    {
        foreach (var weapon in _weaponsTransform)
        {
            weapon.gameObject.SetActive(false);
        }

        _weaponsTransform[weaponsType.GetHashCode()].gameObject.SetActive(true);
    }

    private void SetWeaponData(WeaponsType weaponsType)
    {
        var currentWeaponData = _weaponsData[weaponsType.GetHashCode()];
        OnWeaponChanged?.Invoke(currentWeaponData);
    }

    private void SetBarrerTransform(WeaponsType weaponsType)
    {
        var currentBarrelTarnsform = _barrelsTransform[weaponsType.GetHashCode()];
        OnBarrelChanged?.Invoke(currentBarrelTarnsform);
    }

    private void OnDisable()
    {
        _inputWrapper.OnWeaponChanged -= SetWeapon;
        _inputWrapper.OnWeaponChanged -= SetWeaponData;
    }
}
