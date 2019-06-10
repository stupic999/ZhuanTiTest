using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    public GameObject self;
    public GameObject player;
    public GameObject gameController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (self.name == "HospitalDoor" && gameControllerScriptableObject.isTalkWithBoy)
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
        SceneManager.LoadScene("LoadingScene");
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(gameController);
    }
    public void GoToScenePark()
    {
        SceneManager.LoadScene("LoadingScene");
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(gameController);
    }
}
