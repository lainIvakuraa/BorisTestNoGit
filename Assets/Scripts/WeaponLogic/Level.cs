using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Level : MonoBehaviour
{
    int experience = 0;
    int level = 1;
    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpgradePanelManager upgradePanel;
    [SerializeField] HighScoreBar highScoreBar;
    [SerializeField] List<UpgradeData> upgrades;
    List<UpgradeData> selectedUpgrades;
    [SerializeField] List<UpgradeData> aquiredUpgrades;
    WeaponManager weaponManager;
    int TO_LEVEL_UP {
        get {
            return level * 1000;
        }
    }
    private void Awake() {
        weaponManager = GetComponent<WeaponManager>();
    }
    private void Start() {
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        highScoreBar.UpdateExperienceSlider(experience, PlayerPrefs.GetInt("HighScore", 0));
        experienceBar.SetScoreText(experience);
        AddExperience(1000);
    }
    public void AddExperience(int amount) {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        highScoreBar.UpdateExperienceSlider(experience, PlayerPrefs.GetInt("HighScore", 0));
        experienceBar.SetScoreText(experience);
    }
    public void AddUpgradesIntoTheListOfAvalibleUpgrades(List<UpgradeData> upgradesToAdd) {
        this.upgrades.AddRange(upgradesToAdd);
    }
    public void Upgrade(int selectedUpgradeID) {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradeID];

        if (aquiredUpgrades == null) {aquiredUpgrades = new List<UpgradeData>();}

        switch (upgradeData.upgradeType) {
            case UpgradeType.WeaponUpgrade:
            weaponManager.UpgradeWeapon(upgradeData);
            AddUpgradesIntoTheListOfAvalibleUpgrades(upgradeData.nextUpgrades);
            break;
            case UpgradeType.ItemUpgrade:
            break;
            case UpgradeType.WeaponUnlock:
            weaponManager.AddWeapon(upgradeData.weaponData);
            break;
            case UpgradeType.ItemUnlock:
            break;
        }
        aquiredUpgrades.Add(upgradeData);
        upgrades.Remove(upgradeData);
    }

    public void CheckLevelUp() {
        if (experience >= TO_LEVEL_UP) {
            LevelUp();
        }
    }
    private void LevelUp() {
        if (selectedUpgrades == null) { selectedUpgrades = new List<UpgradeData>();}
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgrades(4));
        upgradePanel.OpenPanel(selectedUpgrades);
        experience -= TO_LEVEL_UP;
        level += 1;
        //experienceBar.SetScoreText(experience);
    }
    public List<UpgradeData> GetUpgrades(int count) {
        List<UpgradeData> upgradeList = new List<UpgradeData>();
        if (count > upgrades.Count) {
            count = upgrades.Count;
        }
        for(int i = 0; i< count; i++) {
            upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }
        
        return upgradeList;
    }
}
