using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Скрипт конца игры
public class CharachterGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField] HighScoreTable highScoreTable;
    [SerializeField] PauseGameManager pauseGameManager;
    [SerializeField] GameObject weaponParent;
    private void Awake() {
        //highScoreTable = GetComponent<HighScoreTable>();
        //pauseGameManager = GetComponent<PauseGameManager>();
    }
    public void GameOverFunc() {
        Debug.Log("Game Over");
        GetComponent<PlayerMove>().enabled = false;
        gameOverPanel.SetActive(true);
        pauseGameManager.PauseGame();
        highScoreTable.UpdateHighscore();
        weaponParent.SetActive(false);
        
    }
}
