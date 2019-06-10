using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPause : MonoBehaviour {

    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    public GameObject MoveUI;
    public GameObject ClockUI;
    public GameObject LightUI;
    public GameObject SettingUI;

    private void Update()
    {
        if (gameControllerScriptableObject.isPause)
        {
            MoveUI.SetActive(false);
            SettingUI.SetActive(false);
            ClockUI.SetActive(false);
        }
        else
        {
            MoveUI.SetActive(true);
            SettingUI.SetActive(true);
            ClockUI.SetActive(true);
        }
        if (gameControllerScriptableObject.isNight && !gameControllerScriptableObject.isPause)
        {
            LightUI.SetActive(true);
        }
        else
        {
            LightUI.SetActive(false);
        }
    }
}
