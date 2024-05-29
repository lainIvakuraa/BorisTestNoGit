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
    public WeaponStats(int damage, float timeToAttack, int numberOfAttacks, int pierceCount) {
        this.damage = damage;
        this.timeToAttack = timeToAttack;
        this.numberOfAttacks = numberOfAttacks;
        this.pierceCount = pierceCount;
    }
    public void Sum(WeaponStats weaponUpgradeStats) {
        this.damage += weaponUpgradeStats.damage;
        this.timeToAttack += weaponUpgradeStats.timeToAttack;
        this.numberOfAttacks += weaponUpgradeStats.numberOfAttacks;
        this.pierceCount += weaponUpgradeStats.pierceCount;
    }
}


[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string Name;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;
    public List<UpgradeData> upgrades;
    
}