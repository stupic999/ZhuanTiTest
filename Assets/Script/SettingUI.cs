using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour {

    public GameObject settingUI;
    public GameObject GameScene;
    public GameObject MainMenu;
    public GameObject SoundSettingUI;
    public GameObject mainCamare;

    public void ShowSettingUI()
    {
        if (!GameController.isPause)
        {
            AudioController.btnSound = true;
            settingUI.SetActive(true);
            GameController.isPause = true;
        }
    }

    public void ContinueGame()
    {
        AudioController.btnSound = true;
        settingUI.SetActive(false);
        GameController.isPause = false;
    }

    public void GoToMainMenu()
    {
        AudioController.btnSound = true;
        GameController.isPause = true;
        settingUI.SetActive(false);
        GameScene.SetActive(false);
        MainMenu.SetActive(true);
        mainCamare.SetActive(true);
    }

    public void ShowSettingUI2()
    {
        AudioController.btnSound = true;
        SoundSettingUI.SetActive(true);
        settingUI.SetActive(false);
    }

    public void CloseSoundSettingUI()
    {
        AudioController.btnSound = true;
        SoundSettingUI.SetActive(false);
        GameController.isPause = false;
    }
}
