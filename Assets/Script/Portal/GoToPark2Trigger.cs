﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPark2Trigger : MonoBehaviour {

    [SerializeField]
    DialogueScriptable goParkDialogue;
    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    public GameObject YesOrNo;
    public GameObject ContinueBtn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            gameControllerScriptableObject.isPause = true;
            gameControllerScriptableObject.PortalPlace = "GoToPark2";
            TriggerDialogue(goParkDialogue.dialogue);
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
