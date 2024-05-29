using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelManager : MonoBehaviour
{
   [SerializeField] GameObject upgradePanel;
   PauseGameManager pauseManager;
   [SerializeField] List<UpgradeButton> upgradeButtons;
   [SerializeField] GameObject selectButton;
   [SerializeField] TMPro.TextMeshProUGUI UpgradeTitle;
    [SerializeField] TMPro.TextMeshProUGUI UpgradeDescription;
   [SerializeField] Level charachterLevel;
   private int pressedButtonNumber;
   List<UpgradeData> upgradeData;
   
   private void Awake() {
        pauseManager = GetComponent<PauseGameManager>();
        //charachterLevel = GameManager.instance.playerTransform.GetComponent<Level>();

    }
    private void Start() {
      HideButtons();
    }
   public void OpenPanel(List<UpgradeData> upgradeDatas) {
    Clean();
    pauseManager.PauseGame();
    upgradePanel.SetActive(true);

    this.upgradeData = upgradeDatas;

    for(int i =0; i < upgradeDatas.Count; i++) {
      upgradeButtons[i].gameObject.SetActive(true);
      upgradeButtons[i].Set(upgradeDatas[i]);
    }
   }
   public void Clean() {
    for (int i = 0; i < upgradeButtons.Count; i++) {
      upgradeButtons[i].Clean();
    }
   }
  /*public void SetUpgradeButtonPressed(int upgradeButtonId) {
    this.pressedButtonID = upgradeButtonId;
  }*/
   public void Upgrade(int pressedButtonID) {
    if (pressedButtonNumber != pressedButtonID) {
      pressedButtonNumber = pressedButtonID;
      ShowUpgradeInfo(pressedButtonID);
    } else {
      charachterLevel.Upgrade(pressedButtonID);
      ClosePanel();
    }
   }
   public void ShowUpgradeInfo(int pressedButtonID) {
    selectButton.SetActive(true);
    UpgradeTitle.text = upgradeData[pressedButtonID].Name;
    UpgradeDescription.text = upgradeData[pressedButtonID].description;
   }
  /* public void aquireUpgrade() {
    .Upgrade(pressedButtonNumber);
    ClosePanel();
   }*/
   public void ClosePanel() {
    HideButtons();
    pauseManager.UnPauseGame();
    upgradePanel.SetActive(false);
   }
   private void HideButtons() {
    for (int i = 0; i < upgradeButtons.Count; i++) {
      upgradeButtons[i].gameObject.SetActive(false);
    }
   }
}
