using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour {

    public GameObject HouseLgtPzlDone;
    public GameObject HouseLgtPzlYet;
    public GameObject HouseDkPzlDone;
    public GameObject HouseDkPzlYet;

    public void Update()
    {
        if (GameController.isCloseLight != true && GameController.isDonePuzzle != true)
        {
            HouseLgtPzlYet.SetActive(true);
            HouseDkPzlYet.SetActive(false);
            HouseLgtPzlDone.SetActive(false);
            HouseDkPzlDone.SetActive(false);
        }
        else if (GameController.isCloseLight != false && GameController.isDonePuzzle != true)
        {
            HouseLgtPzlYet.SetActive(false);
            HouseDkPzlYet.SetActive(true);
            HouseLgtPzlDone.SetActive(false);
            HouseDkPzlDone.SetActive(false);
        }
        else if (GameController.isCloseLight != false && GameController.isDonePuzzle != false)
        {
            HouseLgtPzlYet.SetActive(false);
            HouseDkPzlYet.SetActive(false);
            HouseLgtPzlDone.SetActive(false);
            HouseDkPzlDone.SetActive(true);
        }
        else if (GameController.isCloseLight != true && GameController.isDonePuzzle != false) 
        {
            HouseLgtPzlYet.SetActive(false);
            HouseDkPzlYet.SetActive(false);
            HouseLgtPzlDone.SetActive(true);
            HouseDkPzlDone.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameController.btnEvent = "Light";
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
