using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
   [SerializeField] GameObject upgradePanel;
   PauseGameManager pauseManager;
   private void Awake() {
        pauseManager = GetComponent<PauseGameManager>();
    }
   public void OpenPanel() {
    pauseManager.PauseGame();
    upgradePanel.SetActive(true);
   }
   public void ClosePanel() {
    pauseManager.UnPauseGame();
    upgradePanel.SetActive(false);
   }
}
