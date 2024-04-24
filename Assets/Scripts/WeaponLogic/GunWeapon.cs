using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : WeaponBase
{
    [SerializeField] GameObject bulletPrefab;

    public override void Attack() {
        GameObject shotBullet = Instantiate(bulletPrefab);
        shotBullet.transform.position = transform.position;
        bulletProjectile bulletProjectileCurrent = shotBullet.GetComponent<bulletProjectile>();
        bulletProjectileCurrent.SetDirection(); //FindObjectOfType<Charachter>().transform.position
        bulletProjectileCurrent.damage = weaponStats.damage;
    }
    
}
