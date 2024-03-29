using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
   [SerializeField] GameObject upgradePanel;
   PauseGameManager pauseManager;
   [SerializeField] List<UpgradeButton> upgradeButtons;
   private void Awake() {
        pauseManager = GetComponent<PauseGameManager>();
    }
    private void Start() {
      HideButtons();
    }
   public void OpenPanel(List<UpgradeData> upgradeDatas) {
    Clean();
    pauseManager.PauseGame();
    upgradePanel.SetActive(true);

    

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
   public void Upgrade(int pressedButtonID) {
    GameManager.instance.playerTransform.GetComponent<Level>().Upgrade(pressedButtonID);
    ClosePanel();
   }
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
