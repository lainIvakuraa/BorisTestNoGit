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
            Attack();
            timer = weaponStats.timeToAttack;
        }
    }

    public virtual void SetData(WeaponData wd) {
        weaponData = wd;
        TimeToAttack = weaponData.stats.timeToAttack;

        weaponStats = new WeaponStats(wd.stats.damage, wd.stats.timeToAttack);
    }
    public abstract void Attack();

    public void Upgrade(UpgradeData upgradeData) {
        weaponStats.Sum(upgradeData.weaponUpgradeStats);
    }
}
