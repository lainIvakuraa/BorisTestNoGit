using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponStats {
    public int damage;
    public float timeToAttack;
    public int numberOfAttacks;
    public int pierceCount;
    public int bulletRange;
    public int bulletSpeed;
    public WeaponStats(int damage, float timeToAttack, int numberOfAttacks, int pierceCount, int bulletRange, int bulletSpeed) {
        this.damage = damage;
        this.timeToAttack = timeToAttack;
        this.numberOfAttacks = numberOfAttacks;
        this.pierceCount = pierceCount;
        this.bulletRange = bulletRange;
        this.bulletSpeed = bulletSpeed;
    }
    public void Sum(WeaponStats weaponUpgradeStats) {
        this.damage += weaponUpgradeStats.damage;
        this.timeToAttack += weaponUpgradeStats.timeToAttack;
        this.numberOfAttacks += weaponUpgradeStats.numberOfAttacks;
        this.pierceCount += weaponUpgradeStats.pierceCount;
        this.bulletRange += weaponUpgradeStats.bulletRange;
        this.bulletSpeed += weaponUpgradeStats.bulletSpeed;
    }
}


[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string Name;
    public string description;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;
    public List<UpgradeData> upgrades;
    
}