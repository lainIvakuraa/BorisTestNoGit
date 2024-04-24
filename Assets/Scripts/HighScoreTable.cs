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
    /*private void Awake() {
        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = transform.Find("HighscoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 20f;

        for (int i = 0; i < 10; i++) {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0,  -templateHeight * i);
            entryTransform.gameObject.SetActive(true);
        }
    }*/
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
