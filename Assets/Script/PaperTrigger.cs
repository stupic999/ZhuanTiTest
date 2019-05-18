using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && !GameController.isCheckPool)
        {
            GameController.btnEvent = "Paper";
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
