using System;
using UnityEngine;

[Serializable]
public class Weapon
{
    // Weapon
    //  - WeaponType {HG, SG, SMG, MG, FT, MT, AR, SR, RG, RL}
    //  - Ammo
    //  - Accuracy
    //  - Damage
    //  - Magazine Max Capacity
    //  - Magazine Current Capacity
    //  - GameObject Ammo Projectile
    //  - Bullet Per Shoot
    //  - Shoot Per Bullet Delay
    //  - Normal Attack Delay
    //  - Reload Speed
    //  - Reload Time Counter

    [SerializeField] public enum WeaponType { HG, SG, SMG, MG, FT, MT, AR, SR, RG, RL}

    [field : SerializeField] public WeaponType Type { get; private set; }
    [field : SerializeField] public GameObject AmmoProjectile { get; private set; }
    [field : SerializeField] public float AttackRange { get; private set; }
    [field : SerializeField] public float Accuracy { get; private set; }
    [field : SerializeField] public float Damage { get; private set; }
    [field : SerializeField] public int MagazineMaxCapacity { get; private set; }
    [field : SerializeField] public int MagazineCurrentCapacity { get; private set; }
    [field : SerializeField] public int BulletPerShoot { get; private set; }
    [field : SerializeField] public float ShootPerBulletDelay { get; private set; }  // note 1f for 1 second
    [field : SerializeField] public float NormalAttackDelay { get; private set; }    // note 1f for 1 second
    [field : SerializeField] public float ReloadSpeed { get; private set; }          // note 1f for 1 second

    public Weapon(
        WeaponType type, 
        float accuracy, 
        float damage, 
        GameObject ammoProjectile,
        int magazineMaxCapacity,
        int bulletPerShoot, 
        float shootPerBulletDelay, 
        float normalAttackDelay, 
        float reloadSpeed,
        float attackRange
    ) {
        Type = type;
        Accuracy = accuracy;
        Damage = damage;
        MagazineMaxCapacity = magazineMaxCapacity;
        MagazineCurrentCapacity = magazineMaxCapacity;
        AmmoProjectile = ammoProjectile;
        BulletPerShoot = bulletPerShoot;
        ShootPerBulletDelay = shootPerBulletDelay;
        NormalAttackDelay = normalAttackDelay;
        ReloadSpeed = reloadSpeed;
        AttackRange = attackRange;
    }
}