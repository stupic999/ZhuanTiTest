using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupBoardTrigger : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" && GameController.btnEvent!="Bear" && !GameController.isCheckCupBoard)
        {
            GameController.btnEvent = "CupBoard";
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
