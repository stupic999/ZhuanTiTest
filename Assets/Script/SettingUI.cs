using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour {

    [SerializeField]
    AudioScriptableObject audioScriptableObject;
    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    public GameObject MainMenu;
    public GameObject settingUI;
    public GameObject GameScene;
    public GameObject mainCamare;
    public GameObject SoundSettingUI;

    public void ShowSettingUI()
    {
        if (!gameControllerScriptableObject.isPause)
        {
            audioScriptableObject.btnSound = true;
            settingUI.SetActive(true);
            gameControllerScriptableObject.isPause = true;
        }
    }

    public void ContinueGame()
    {
        audioScriptableObject.btnSound = true;
        settingUI.SetActive(false);
        gameControllerScriptableObject.isPause = false;
    }

    public void GoToMainMenu()
    {
        audioScriptableObject.btnSound = true;
        gameControllerScriptableObject.isPause = true;
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
        gameControllerScriptableObject.isPause = false;
    }
}
