using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperTrigger : MonoBehaviour {

    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && !gameControllerScriptableObject.isCheckPool)
        {
            gameControllerScriptableObject.btnEvent = "Paper";
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
