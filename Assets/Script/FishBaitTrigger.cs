using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBaitTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && GameController.isSeePaper != false && GameController.isTakeFishBait != true) 
        {
            GameController.btnEvent = "FishBait";
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
