using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponData weaponData;
    public WeaponStats weaponStats;
    public float TimeToAttack = 0.5f;
    float timer;
    public void Update() {
        timer -= Time.deltaTime;
        if (timer < 0f) {
            timer = weaponStats.timeToAttack;
            Attack();

        }
    }
    /*public void ApplyDamage(Collider2D[] colliders) {
        int damage = GetDamage();
        for (int i = 0; i < colliders.Length, i++) {
            IDamageable e = colliders[i].GetComponent<IDamagable>();
            if (e != null) {
                PostDamage(damage, colliders[i].transform.position);
                e.TakeDamage(damage);
            }
        }
    }*/

    public virtual void SetData(WeaponData wd) {
        weaponData = wd;
        TimeToAttack = weaponData.stats.timeToAttack;

        weaponStats = new WeaponStats(wd.stats.damage, wd.stats.timeToAttack, wd.stats.numberOfAttacks);
    }
    public abstract void Attack();

    public void Upgrade(UpgradeData upgradeData) {
        weaponStats.Sum(upgradeData.weaponUpgradeStats);
    }
}
