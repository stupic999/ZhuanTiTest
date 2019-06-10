using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTrigger : MonoBehaviour {

    [SerializeField]
    TimerScriptableObject timerScriptableObject;
    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;

    private void Update()
    {
        if (gameControllerScriptableObject.isPause != true)
            timerScriptableObject.grassTimer += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" && gameControllerScriptableObject.isCheckGrass != true && timerScriptableObject.grassTimer >= 0.5)
        {
            gameControllerScriptableObject.btnEvent = "Grass";
            timerScriptableObject.grassTimer = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            gameControllerScriptableObject.btnEvent = "";
        }
    }
}
