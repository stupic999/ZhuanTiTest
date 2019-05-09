using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseOutsideTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("GoOut?");
        }
    }
}
