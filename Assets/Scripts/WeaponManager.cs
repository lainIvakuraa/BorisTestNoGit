using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponObjectsContainer;
    [SerializeField] WeaponData startingWeapon;
    List<WeaponBase> weaponBases; //список имеющегося у персонажа оружия
    private void Awake() {
        weaponBases = new List<WeaponBase>();
    }
    private void Start() {
        //AddWeapon(startingWeapon);
    }
    public void AddWeapon(WeaponData weaponData)  {
        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectsContainer);
        WeaponBase weaponBase = weaponGameObject.GetComponent<WeaponBase>();
        weaponBase.SetData(weaponData);
        weaponBases.Add(weaponBase);
        Level level = GetComponent<Level>();
        if (level != null) {
            level.AddUpgradesIntoTheListOfAvalibleUpgrades(weaponData.upgrades);
        }
    }
    public void UpgradeWeapon(UpgradeData upgradeData) {
        WeaponBase weaponToUpgrade = weaponBases.Find(wd => wd.weaponData == upgradeData.weaponData);
        weaponToUpgrade.Upgrade(upgradeData);
    }
}
