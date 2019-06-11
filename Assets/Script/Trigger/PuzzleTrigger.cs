using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour {

    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && !gameControllerScriptableObject.isDonePuzzle)
        {
            gameControllerScriptableObject.btnEvent = "Puzzle";
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
