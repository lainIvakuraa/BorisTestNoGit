using System;
using System.Collections;
using System.Collections.Generic;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public string upgradeName;
    public string upgradeDescription;
    public int buttonId;
     [SerializeField] UpgradePanelManager uPanel;
    
    [SerializeField] UnityEngine.UI.Image icon;
    public void Set(UpgradeData upgradeData) {
        icon.sprite = upgradeData.icon;
        this.upgradeName = upgradeData.Name;
        //this.upgradeDescription = upgradeData.Description;
        
    }
    void Start() {

    }
    public string GetUpgradeName() {
        return this.upgradeName;
    }
    public string GetUpgradeDescription() {
        return this.upgradeDescription;
    }
    
    public void Clean() {
        icon.sprite = null;
    }

}
