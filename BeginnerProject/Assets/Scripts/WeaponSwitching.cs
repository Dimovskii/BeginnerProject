using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    [SerializeField] private Transform[] _weapons;
    [SerializeField] private KeyCode[] _keys;
    [SerializeField] private GunData[] _guns;
    private float _switchTime;
    private int _selectedWeapon;
    private float _timeSinceLastSwitch;


    private void Start() 
    {
        SetWeapons();
        Select(_selectedWeapon);

        _timeSinceLastSwitch = 0f;
        _switchTime = 0.2f;
    }

    private void Update() 
    {
        int previoesSelectedWeapon = _selectedWeapon;

        for (int i = 0; i < _keys.Length; i++)
        {
            if (Input.GetKeyDown(_keys[i]) && _timeSinceLastSwitch >= _switchTime)
                _selectedWeapon = i;
        }    

        if (previoesSelectedWeapon != _selectedWeapon)
        {
            Select(_selectedWeapon);    
        }

        _timeSinceLastSwitch += Time.deltaTime;
    }

    private void SetWeapons()
    {
        _weapons = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _weapons[i] = transform.GetChild(i);
        }

        if (_keys == null)
        {
            _keys = new KeyCode[_weapons.Length];
        }
    }

    private void Select(int weaponIndex)
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            _weapons[i].gameObject.SetActive(i == weaponIndex);
        }

        _timeSinceLastSwitch = 0f;
    }
}
