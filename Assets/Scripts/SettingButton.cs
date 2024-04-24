using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingButton : MonoBehaviour
{
    [SerializeField] GameObject SettingPanel;
    public void CloseSetting()
    {
        SettingPanel.SetActive(false);
    }
    public void OpenSetting()
    {
        SettingPanel.SetActive(true);
    }
}
