using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperTrigger : MonoBehaviour {

    bool ShowMap;
    public GameObject Map;

    public void Start()
    {
        ShowMap = false;
        Map.SetActive(false);
    }

    public void Update()
    {
        if (GameController.isSeePaper != false && ShowMap != true) 
        {
            Map.SetActive(true);
            ShowMap = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && GameController.isSeePaper != true)
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
