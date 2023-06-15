using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Weapon;
using System;

public class WeaponBar : MonoBehaviour
{
    [SerializeField] private List<Image> _weaponIcon;
    [SerializeField] private Text _ammoAmount;
    private IShoot _shooting;
    private IInput _input;
    private IReload _reload;
    private ISwitcher _switcher;

    public void Init(IShoot shooting, IInput input, IReload reload, ISwitcher switcher)
    {
        _input = input;
        _shooting = shooting;
        _reload = reload;
        _switcher = switcher;
        Subscribe();
    }

    private void Subscribe()
    {
        _input.OnWeaponChanged += SetWeaponIcon;
        _shooting.OnShootHappened += SetAmmoAmount;
        _reload.OnReloaded += SetAmmoAmount;
        _switcher.OnGunChanged += GetAmmoAmount;
    }

    private void SetWeaponIcon(int idWeapon)
    {
        foreach (var icon in _weaponIcon)
        {
            icon.gameObject.SetActive(false);
        }

        _weaponIcon[idWeapon].gameObject.SetActive(true);
    }
    private void GetAmmoAmount(WeaponData data)
    {
        SetAmmoAmount(data.CurrentAmmoCount, data.MaxAmmoCount);
    }

    private void SetAmmoAmount(int current, int max)
    {
        var currentText = current.ToString();
        var maxText = max.ToString();

        _ammoAmount.text = $"{currentText}/{max}";
    }

    private void OnDisable()
    {
        _input.OnWeaponChanged -= SetWeaponIcon;
        _shooting.OnShootHappened -= SetAmmoAmount;
    }
}
