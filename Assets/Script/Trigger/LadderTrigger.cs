using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTrigger : MonoBehaviour {

    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && !gameControllerScriptableObject.isCheckLadder)
        {
            gameControllerScriptableObject.btnEvent = "Ladder";
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
