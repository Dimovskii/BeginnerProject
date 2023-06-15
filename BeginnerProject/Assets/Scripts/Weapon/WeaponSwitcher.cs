using UnityEngine;
using System.Collections.Generic;
using System;

public class WeaponSwitcher : MonoBehaviour, ISwitcher
{
    [SerializeField] private List<Transform> _weaponsTransform;
    [SerializeField] private List<Transform> _barrelsTransform;
    [SerializeField] private List<WeaponData> _weaponsData;
    private IInput InputWrapper;
    public event Action<WeaponData> OnGunChanged;
    public event Action<Transform> OnBarrelChanged;
    public void Init(IInput inputWrapper)
    {
        InputWrapper = inputWrapper;
        Discribe();
    }

    private void Discribe()
    {
        InputWrapper.OnWeaponChanged += SetWeapon;
        InputWrapper.OnWeaponChanged += SetWeaponData;
        InputWrapper.OnWeaponChanged += SetBarrel;
    }

    private void SetWeapon(int idWeapon)
    {
        foreach (var weapon in _weaponsTransform)
        {
            weapon.gameObject.SetActive(false);
        }

        _weaponsTransform[idWeapon].gameObject.SetActive(true);
    }

    private void SetWeaponData(int idWeapon)
    {
        var currentWeaponData = _weaponsData[idWeapon];
        OnGunChanged?.Invoke(currentWeaponData);
    }

    private void SetBarrel(int idWeapon)
    {
        var currentBarrelTarnsform = _barrelsTransform[idWeapon];
        OnBarrelChanged?.Invoke(currentBarrelTarnsform);
    }

    private void OnDisable()
    {
        InputWrapper.OnWeaponChanged -= SetWeapon;
        InputWrapper.OnWeaponChanged -= SetWeaponData;
        InputWrapper.OnWeaponChanged -= SetBarrel;
    }
}
