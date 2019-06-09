using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTrigger : MonoBehaviour {

    [SerializeField]
    TimerScriptableObject timerScriptableObject;

    private void Update()
    {
        if (GameController.isPause != true)
            timerScriptableObject.grassTimer += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" && GameController.isCheckGrass != true && timerScriptableObject.grassTimer >= 0.5)
        {
            GameController.btnEvent = "Grass";
            timerScriptableObject.grassTimer = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameController.btnEvent = "";
        }
    }
}
