using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

    public GameObject player;
    public GameObject gameController;
    public GameObject self;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (self.name == "HospitalDoor" && GameController.isTalkWithBoy)
            {
                GoToScenePark();
            }
            if (self.name == "ParkDoor")
            {
                GoToSceneHospital();
            }
        }
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
}
