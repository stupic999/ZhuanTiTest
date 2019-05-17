using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPause : MonoBehaviour {

    public GameObject MoveUI;
    public GameObject SettingUI;

    private void Update()
    {
        if (GameController.isPause)
        {
            MoveUI.SetActive(false);
            SettingUI.SetActive(false);
        }
        else
        {
            MoveUI.SetActive(true);
            SettingUI.SetActive(true);
        }
    }
}
