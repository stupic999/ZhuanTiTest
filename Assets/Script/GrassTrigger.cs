using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTrigger : MonoBehaviour {

    float GrassTimer=1;

    private void Update()
    {
        if(GameController.isPause!=true)
        GrassTimer += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" && GameController.isCheckGrass != true && GrassTimer>=0.5)
        {
            GameController.btnEvent = "Grass";
            GrassTimer = 0;
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
