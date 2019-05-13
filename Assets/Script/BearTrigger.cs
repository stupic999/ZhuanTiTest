using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrigger : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameController.btnEvent = "Bear";
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
