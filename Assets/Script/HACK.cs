using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HACK : MonoBehaviour {

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            HACK1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HACK2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            HACK3();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            HACK4();
        }
    }

    public void HACK1()
    {
        GameController.LoadingSceneName = "Start";
        SceneManager.LoadScene("LoadingScene");
    }
    public void HACK2()
    {
        GameController.LoadingSceneName = "LoadingScene";
        SceneManager.LoadScene("LoadingScene");
    }
    public void HACK3()
    {
        GameController.LoadingSceneName = "Hospital";
        SceneManager.LoadScene("LoadingScene");
    }
    public void HACK4()
    {
        GameController.LoadingSceneName = "SampleScene";
        SceneManager.LoadScene("LoadingScene");
    }
}
