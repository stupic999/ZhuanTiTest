using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoesTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameController.btnEvent = "Shoes";
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
