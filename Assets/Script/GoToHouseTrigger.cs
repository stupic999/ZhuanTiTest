using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToHouseTrigger : MonoBehaviour {

    public Dialogue GoOrNot;
    public GameObject YesOrNo;
    public GameObject ContinueBtn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameController.isPause = true;
            GameController.PortalPlace = "GoToHouse";
            TriggerDialogue(GoOrNot);
            YesOrNo.SetActive(true);
            ContinueBtn.SetActive(false);           
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
