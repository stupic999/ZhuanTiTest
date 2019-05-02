using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HACK : MonoBehaviour {

    public GameObject player;
    public GameObject gameController;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GoToSceneStart();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GoToSceneHospital();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GoToScenePark();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GoToSceneFood();
        }
    }

    public void GoToSceneStart()
    {
        GameController.LoadingSceneName = "Start";
        SceneManager.LoadScene("LoadingScene");
    }
    public void GoToSceneHospital()
    {
        GameController.LoadingSceneName = "Hospital";
        SceneManager.LoadScene("LoadingScene");
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(gameController);
    }
    public void GoToScenePark()
    {     
        GameController.LoadingSceneName = "Park";
        SceneManager.LoadScene("LoadingScene");
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(gameController);
    }
    public void GoToSceneFood()
    {
        GameController.LoadingSceneName = "SampleScene";
        SceneManager.LoadScene("LoadingScene");
    }
}
