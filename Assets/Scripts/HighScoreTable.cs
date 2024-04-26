using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    [SerializeField] ExperienceBar expBar;
    [SerializeField] TextMeshProUGUI highScoreText;
    int highscore;
    private void Start() {
        UpdateHighScoreText();
    }
    public void UpdateHighscore() {
        int currentScore =  expBar.GetExp();
        if (currentScore > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", currentScore);
            UpdateHighScoreText();
        }
    }
    private void UpdateHighScoreText() {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}

