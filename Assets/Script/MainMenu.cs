using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    AudioScriptableObject audioScriptableObject;
    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    bool isStart;
    bool isSetting;
    public Animator StartAnim;
    public GameObject mainMenu;
    public GameObject gameScene;
    public GameObject SoundSettingUI;

    public void StartGame()
    {
        if (!isSetting)
        {
            isStart = true;
            mainMenu.SetActive(false);
            gameScene.SetActive(true);
            gameControllerScriptableObject.isPause = false;
            StartAnim.SetBool("isStart", true);
            audioScriptableObject.btnSound = true;
        }
    }

    public void ContinueGame()
    {
        if (!isSetting)
        {
            if (isStart)
            {
                gameControllerScriptableObject.isPause = false;
                mainMenu.SetActive(false);
                gameScene.SetActive(true);
                StartAnim.SetBool("isStart", true);
                audioScriptableObject.btnSound = true;
            }
            else
            {
                audioScriptableObject.error = true;
            }
        }
    }

    public void ShowSettingUI()
    {
        if (!isSetting)
        {
            isSetting = true;
            gameScene.SetActive(false);
            SoundSettingUI.SetActive(true);
            audioScriptableObject.btnSound = true;
        }
    }


    public void QuitGame()
    {
        if (!isSetting)
        {
            Debug.Log("Quit");
            Application.Quit();
            audioScriptableObject.btnSound = true;
        }
    }

    public void CloseSoundSettingUI()
    {
        SoundSettingUI.SetActive(false);
        mainMenu.SetActive(true);
        audioScriptableObject.btnSound = true;
        isSetting = false;
    }
}
