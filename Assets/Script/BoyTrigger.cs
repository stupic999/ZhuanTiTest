using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && GameController.isTalkWithBoy!=true)
        {
            GameController.btnEvent = "Boy";
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
