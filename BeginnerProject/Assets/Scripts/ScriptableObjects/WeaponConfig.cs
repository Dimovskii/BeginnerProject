using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "WeaponConfig/NewWeapon", order = 51)]
public class WeaponConfig : ScriptableObject 
{
    public string Name;
    public GameObject WeaponPrefab;
    public GameObject BulletPrefab;
    public int BulletSpeed;
    public int Damage;
    public int MaxAmmoCount;
    public int CurrentAmmoCount;
    public float FireRate;
    public float ReloadTime;
    public bool IsAutomatic;
}