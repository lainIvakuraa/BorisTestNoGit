using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    [SerializeField] Transform bar;
    [SerializeField] Slider slider;

    /*public void SetState(int current, int max) {
        float state = (float)current;
        state /= max;
        if (state < 0f) {state = 0f;};
        bar.transform.localScale = new Vector3(state, 1f, 1f);
    }*/
    public void SetState(int current, int target) {
        slider.maxValue = target;
        slider.value = current;
    }
    
}
