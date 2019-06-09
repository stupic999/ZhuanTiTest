using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour {

    [SerializeField]
    AudioScriptableObject audioScriptableObject;
    public GameObject MainMenu;
    public GameObject settingUI;
    public GameObject GameScene;
    public GameObject mainCamare;
    public GameObject SoundSettingUI;

    public void ShowSettingUI()
    {
        if (!GameController.isPause)
        {
            audioScriptableObject.btnSound = true;
            settingUI.SetActive(true);
            GameController.isPause = true;
        }
    }

    public void ContinueGame()
    {
        audioScriptableObject.btnSound = true;
        settingUI.SetActive(false);
        GameController.isPause = false;
    }

    public void GoToMainMenu()
    {
        audioScriptableObject.btnSound = true;
        GameController.isPause = true;
        settingUI.SetActive(false);
        GameScene.SetActive(false);
        MainMenu.SetActive(true);
        mainCamare.SetActive(true);
    }

    public void ShowSettingUI2()
    {
        audioScriptableObject.btnSound = true;
        SoundSettingUI.SetActive(true);
        settingUI.SetActive(false);
    }

    public void CloseSoundSettingUI()
    {
        audioScriptableObject.btnSound = true;
        SoundSettingUI.SetActive(false);
        GameController.isPause = false;
    }
}
