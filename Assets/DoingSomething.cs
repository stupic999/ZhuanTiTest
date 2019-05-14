using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoingSomething : MonoBehaviour {

    public Dialogue DigDialogue;
    public GameObject UI;
    public GameObject DigPic;
    float ShowTimer;

	// Update is called once per frame
	void Update () {
        if (GameController.EventName == "Dig" && ShowTimer<3)
        {
            UI.SetActive(true);
            ShowTimer += Time.deltaTime;
            GameController.isPause = true;
            Destroy(DigPic);
        }
        else if(ShowTimer>3 && GameController.EventName == "Dig")
        {
            GameController.EventName = "";
            UI.SetActive(false);
            ShowTimer = 0;
            TriggerDialogue(DigDialogue);
        }
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
