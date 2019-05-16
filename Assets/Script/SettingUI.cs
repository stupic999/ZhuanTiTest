using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour {

    public GameObject settingUI;
    public GameObject GameScene;
    public GameObject MainMenu;
    public GameObject SoundSettingUI;

    public void ShowSettingUI()
    {
        if (!GameController.isPause)
        {
            settingUI.SetActive(true);
            GameController.isPause = true;
        }
    }

    public void ContinueGame()
    {
        settingUI.SetActive(false);
        GameController.isPause = false;
    }

    public void GoToMainMenu()
    {
        settingUI.SetActive(false);
        GameScene.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void ShowSettingUI2()
    {
        SoundSettingUI.SetActive(true);
        settingUI.SetActive(false);
    }

    public void CloseSoundSettingUI()
    {
        Debug.Log(11);
        SoundSettingUI.SetActive(false);
        GameController.isPause = false;
    }
}
