using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToHospitalTrigger : MonoBehaviour {

    public Dialogue GoOrNot;
    public Dialogue CantGo;
    public GameObject YesOrNo;
    public GameObject ContinueBtn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && !ClockTimer.isNight)
        {
            GameController.isPause = true;
            GameController.PortalPlace = "GoToHospital";
            TriggerDialogue(GoOrNot);
            YesOrNo.SetActive(true);
            ContinueBtn.SetActive(false);
        }
        else if (other.transform.tag == "Player" &&  ClockTimer.isNight)
        {
            GameController.isPause=true;
            TriggerDialogue(CantGo);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameController.isPause = false;
            YesOrNo.SetActive(false);
            ContinueBtn.SetActive(true);
        }
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
