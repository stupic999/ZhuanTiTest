using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalDoorTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && GameController.isTalkWithBoy == true)
        {
            GameController.btnEvent = "HospitalDoor";
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
