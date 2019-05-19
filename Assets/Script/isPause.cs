using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPause : MonoBehaviour {

    public GameObject MoveUI;
    public GameObject SettingUI;
    public GameObject ClockUI;
    public GameObject LightUI;

    private void Update()
    {
        if (GameController.isPause)
        {
            MoveUI.SetActive(false);
            SettingUI.SetActive(false);
            LightUI.SetActive(false);
            ClockUI.SetActive(false);
        }
        else
        {
            MoveUI.SetActive(true);
            SettingUI.SetActive(true);
            LightUI.SetActive(true);
            ClockUI.SetActive(true);
        }
    }
}
