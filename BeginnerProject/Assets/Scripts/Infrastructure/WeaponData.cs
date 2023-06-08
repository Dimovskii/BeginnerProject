using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "WeaponData/NewWeaponData", order = 01)]
public class WeaponData : ScriptableObject 
{
    [SerializeField] private string _name;
    [SerializeField] private UnityEngine.GameObject _weaponPrefab;
    [SerializeField] private UnityEngine.GameObject _bulletPrefab;
    [SerializeField] private int _bulletSpeed;
    [SerializeField] private int _damage;
    [SerializeField] private int _maxAmmoCount;
    [SerializeField] private int _currentAmmoCount;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _reloadTime;
    [SerializeField] private bool _isAutomatic;

    public string Name { get => _name; set => _name = value; }
    public UnityEngine.GameObject WeaponPrefab { get => _weaponPrefab; set => _weaponPrefab = value; }
    public UnityEngine.GameObject BulletPrefab { get => _bulletPrefab; set => _bulletPrefab = value; }
    public int BulletSpeed { get => _bulletSpeed; set => _bulletSpeed = value; }
    public int Damage { get => _damage; set => _damage = value; }
    public int MaxAmmoCount { get => _maxAmmoCount; set => _maxAmmoCount = value; }
    public int CurrentAmmoCount { get => _currentAmmoCount; set => _currentAmmoCount = value; }
    public float FireRate { get => _fireRate; set => _fireRate = value; }
    public float ReloadTime { get => _reloadTime; set => _reloadTime = value; }
    public bool IsAutomatic { get => _isAutomatic; set => _isAutomatic = value; }
}