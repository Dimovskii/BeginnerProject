using UnityEngine;
using System.Collections.Generic;
using System;

public class WeaponSwitching : MonoBehaviour
{
    [SerializeField] private List<Transform> _weaponsTransform;
    [SerializeField] private List<Transform> _barrelsTransform;
    [SerializeField] private List<WeaponData> _weaponsData;
    private InputHandler _inputHandler;
    public event Action<WeaponData> OnWeaponDataChanged;
    public event Action<Transform> OnWeaponBarrelChanged;

    private void Awake()
    {
        _inputHandler = GetComponent<InputHandler>();
    }

    private void OnEnable()
    {
        _inputHandler.OnWeaponChanged += SetWeapon;
        _inputHandler.OnWeaponChanged += SetWeaponData;
        _inputHandler.OnWeaponChanged += SetBarrerTransform;
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
        OnWeaponDataChanged?.Invoke(currentWeaponData);
    }

    private void SetBarrerTransform(int idWeapon)
    {
        var currentBarrelTarnsform = _barrelsTransform[idWeapon];
        OnWeaponBarrelChanged?.Invoke(currentBarrelTarnsform);
    }

    private void OnDisable()
    {
        _inputHandler.OnWeaponChanged -= SetWeapon;
        _inputHandler.OnWeaponChanged -= SetWeaponData;
    }
}
