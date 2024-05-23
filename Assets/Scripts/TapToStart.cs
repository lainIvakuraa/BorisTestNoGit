using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStart : MonoBehaviour
{


    [SerializeField] GameObject StartButton;
    [SerializeField] GameObject StartButton2;
    [SerializeField] GameObject StartButton3;
    [SerializeField] GameObject ExitButton;
    [SerializeField] GameObject SettingButton;
    [SerializeField] GameObject TapToStartButton;
    // Start is called before the first frame update

    public void OpenMenu()
    {
        StartButton.SetActive(true);
        StartButton2.SetActive(true);
        StartButton3.SetActive(true);
        ExitButton.SetActive(true);
        SettingButton.SetActive(true);
        TapToStartButton.SetActive(false);
    }


}

