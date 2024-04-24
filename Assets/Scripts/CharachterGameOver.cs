using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Скрипт конца игры
public class CharachterGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField] GameObject weaponParent;
    public void GameOverFunc() {
        Debug.Log("Game Over");
        GetComponent<PlayerMove>().enabled = false;
        gameOverPanel.SetActive(true);
        weaponParent.SetActive(false);
    }
}
