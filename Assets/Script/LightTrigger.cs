using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour {

    public GameObject HouseBgLight;
    public GameObject HouseBgDark;
    public GameObject Photo;

    public void Update()
    {
        if (GameController.isCloseLight != false)
        {
            HouseBgLight.SetActive(false);
            HouseBgDark.SetActive(true);            
            Photo.SetActive(true);
        }
        else
        {
            HouseBgLight.SetActive(true);
            HouseBgDark.SetActive(false);            
            Photo.SetActive(false);
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
