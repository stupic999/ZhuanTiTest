using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && GameController.isDigTreasure != true)
        {
            GameController.btnEvent = "Dig";
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
