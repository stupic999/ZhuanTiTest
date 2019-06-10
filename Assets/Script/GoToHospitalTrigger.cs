using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToHospitalTrigger : MonoBehaviour {

    [SerializeField]
    DialogueScriptable goHospitalDialogue;
    [SerializeField]
    DialogueScriptable cantGo;
    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    public GameObject YesOrNo;
    public GameObject ContinueBtn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && !gameControllerScriptableObject.isNight)
        {
            gameControllerScriptableObject.isPause = true;
            gameControllerScriptableObject.PortalPlace = "GoToHospital";
            YesOrNo.SetActive(true);
            ContinueBtn.SetActive(false);
            TriggerDialogue(goHospitalDialogue.dialogue);
        }
        else if (other.transform.tag == "Player" && gameControllerScriptableObject.isNight)
        {
            gameControllerScriptableObject.isPause=true;
            TriggerDialogue(cantGo.dialogue);
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
