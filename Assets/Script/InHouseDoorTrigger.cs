using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InHouseDoorTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && GameController.isOpenDoor != true)
        {
            GameController.btnEvent = "InHouseDoor";
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
