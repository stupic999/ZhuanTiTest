using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    bool isStart;
    public GameObject mainMenu;
    public GameObject gameScene;
    public Animator StartAnim;
    public GameObject SoundSettingUI;

    public void StartGame()
    {
        isStart = true;
        mainMenu.SetActive(false);
        gameScene.SetActive(true);
        GameController.isPause = false;
        StartAnim.SetBool("isStart", true);
    }

    public void ContinueGame()
    {
        if (isStart)
        {
            mainMenu.SetActive(false);
            gameScene.SetActive(true);
            GameController.isPause = false;
            StartAnim.SetBool("isStart", true);
        }
    }

    public void ShowSettingUI()
    {
        gameScene.SetActive(false);
        SoundSettingUI.SetActive(true); 
    }


    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void CloseSoundSettingUI()
    {
        SoundSettingUI.SetActive(false);
        mainMenu.SetActive(true);
    }
}
