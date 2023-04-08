using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    private int _selectedWeapon = 0;
    private const string _mouseScroll = "Mouse ScrollWheel";

    private void Start() 
    {
        SelectWeapon();    
    }

    private void Update() 
    {
        Switch();
    }

    private void Switch()
    {
        int previouseSelectedWeapon = _selectedWeapon;

        if (Input.GetAxis(_mouseScroll) > 0f)
        {
            if (_selectedWeapon >= transform.childCount -1)
                _selectedWeapon = 0;
            else 
                _selectedWeapon ++;
        }
        if (Input.GetAxis(_mouseScroll) < 0f)
        {
            if (_selectedWeapon <= 0)
                _selectedWeapon = transform.childCount -1;
            else 
                _selectedWeapon --; 
        }

        if (previouseSelectedWeapon != _selectedWeapon)
        {
            SelectWeapon();
        }
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == _selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++; 
        }
    }
}
