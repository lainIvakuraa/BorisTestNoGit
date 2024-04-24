using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMPro.TextMeshProUGUI levelText;
    int total_experience = 0;

    public void UpdateExperienceSlider(int current, int target) {
        slider.maxValue = target;
        slider.value = current;
    }
    public void SetScoreText(int experience) {
        total_experience += experience;
        levelText.text = total_experience.ToString();
    }
}
