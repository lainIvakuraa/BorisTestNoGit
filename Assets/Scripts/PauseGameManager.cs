using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameManager : MonoBehaviour
{
    [SerializeField] GameObject joystick;
    public void PauseGame() {
        Time.timeScale = 0f;
        joystick.SetActive(false);
    }
    public void UnPauseGame() {
        Time.timeScale = 1f;
        joystick.SetActive(true);
    }
}
