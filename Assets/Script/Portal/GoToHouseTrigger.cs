﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToHouseTrigger : MonoBehaviour {

    [SerializeField]
    DialogueScriptable goHouseDialogue;
    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    public GameObject YesOrNo;
    public GameObject ContinueBtn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            gameControllerScriptableObject.isPause = true;
            gameControllerScriptableObject.PortalPlace = "GoToHouse";
            TriggerDialogue(goHouseDialogue.dialogue);
            YesOrNo.SetActive(true);
            ContinueBtn.SetActive(false);           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            gameControllerScriptableObject.isPause = false;
            YesOrNo.SetActive(false);
            ContinueBtn.SetActive(true);
        }
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
