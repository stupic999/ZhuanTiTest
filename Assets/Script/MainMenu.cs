using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

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
            GameController.isPause = false;
            StartAnim.SetBool("isStart", true);
            AudioController.btnSound = true;
        }
    }

    public void ContinueGame()
    {
        if (!isSetting)
        {
            if (isStart)
            {
                GameController.isPause = false;
                mainMenu.SetActive(false);
                gameScene.SetActive(true);
                StartAnim.SetBool("isStart", true);
                AudioController.btnSound = true;
            }
            else
            {
                AudioController.error = true;
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
            AudioController.btnSound = true;
        }
    }


    public void QuitGame()
    {
        if (!isSetting)
        {
            Debug.Log("Quit");
            Application.Quit();
            AudioController.btnSound = true;
        }
    }

    public void CloseSoundSettingUI()
    {
        SoundSettingUI.SetActive(false);
        mainMenu.SetActive(true);
        AudioController.btnSound = true;
        isSetting = false;
    }
}
