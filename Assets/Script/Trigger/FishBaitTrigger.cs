using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBaitTrigger : MonoBehaviour {

    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && gameControllerScriptableObject.isSeeBread != true) 
        {
            gameControllerScriptableObject.btnEvent = "FishBait";
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
