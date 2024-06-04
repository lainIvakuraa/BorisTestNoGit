using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McwaveWeapon : WeaponBase
{
    [SerializeField] GameObject bulletPrefab;

    public override void Attack() {
        GameObject shotBullet = Instantiate(bulletPrefab);
        shotBullet.transform.position = transform.position;
        WaveProjectile bulletProjectileCurrent = shotBullet.GetComponent<WaveProjectile>();
        bulletProjectileCurrent.SpawnProjectile();
        bulletProjectileCurrent.damage = weaponStats.damage;
        bulletProjectileCurrent.SetLifetime(weaponStats.lifeTime);
        bulletProjectileCurrent.SetBulletRange(weaponStats.bulletRange);
    }
    }
    

