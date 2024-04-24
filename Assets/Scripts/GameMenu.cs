using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    PauseGameManager pauseManager;
    void Awake() {
        pauseManager = GetComponent<PauseGameManager>();
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (menuPanel.activeInHierarchy == false) {
                OpenMenu();
            } else {
                CloseMenu();
            }
        }
    }
    public void CloseMenu() {
        pauseManager.UnPauseGame();
        menuPanel.SetActive(false);
    }
    public void OpenMenu() {
        pauseManager.PauseGame();
        menuPanel.SetActive(true);
    }
}
