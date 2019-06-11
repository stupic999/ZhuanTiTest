using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupBoardTrigger : MonoBehaviour {

    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" && gameControllerScriptableObject.btnEvent!="Bear" && !gameControllerScriptableObject.isCheckCupBoard)
        {
            gameControllerScriptableObject.btnEvent = "CupBoard";
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
