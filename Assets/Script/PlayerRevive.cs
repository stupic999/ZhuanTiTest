using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRevive : MonoBehaviour {

    [SerializeField]
    DialogueScriptable playerDie;
    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    public GameObject mainCamare;
    public GameObject Player;
    public Image deadBg;
    public GameObject deadPic;
    public Animator fairyDeadAnim;

    public void ReviveFairy()
    {
        fairyDeadAnim.SetBool("FairyDead", false);
        deadBg.color = new Color(0, 0, 0, 0);
        gameControllerScriptableObject.playerDie = false;
        gameControllerScriptableObject.PlayerRoom = "Hospital";
        Player.transform.position = new Vector3(-231.81f, 1.29f, 0);
        Player.transform.eulerAngles = new Vector3(0, 0, 0);
        mainCamare.transform.position = new Vector3(-231.5f, 0, mainCamare.transform.position.z);
        gameControllerScriptableObject.isGhost = false;
        TriggerDialogue(playerDie.dialogue);
        gameControllerScriptableObject.isNight = false;
        gameControllerScriptableObject.isPause = false;
        deadPic.SetActive(false);
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
