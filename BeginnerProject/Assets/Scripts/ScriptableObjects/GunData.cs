using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Gun")]
public class GunData : ScriptableObject 
{
    public new string name;
    public GameObject BulletType;
    public int CurrentAmmo;
    public int MaxAmmoCount;
    public float FareRate;
    public float ReloadTime;
} 