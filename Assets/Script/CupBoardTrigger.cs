using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupBoardTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
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
