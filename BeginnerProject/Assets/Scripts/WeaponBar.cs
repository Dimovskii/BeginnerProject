using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class WeaponBar : MonoBehaviour
{
    [SerializeField] private List<Image> _weaponIcon;
    [SerializeField] private Text _ammoAmount;
    [SerializeField] private WeaponManager _weaponManager;
    [SerializeField] private PlayerShooting _playerShooting;

    private void OnEnable()
    {
        _playerShooting.OnAmmoAmountChanged += SetAmmoAmount;
        _weaponManager.OnWeaponChanged += SetWeaponIcon;
    }

    private void SetWeaponIcon(int idWeapon)
    {
        foreach (var icon in _weaponIcon)
        {
            icon.gameObject.SetActive(false);
        }

        _weaponIcon[idWeapon].gameObject.SetActive(true);
    }

    private void SetAmmoAmount(int current, int max)
    {
        var currentText = current.ToString();
        var maxText = max.ToString();

        _ammoAmount.text = $"{currentText}/{max}";
    }

    private void OnDisable()
    {
        _playerShooting.OnAmmoAmountChanged -= SetAmmoAmount;
        _weaponManager.OnWeaponChanged -= SetWeaponIcon;
    }
}
