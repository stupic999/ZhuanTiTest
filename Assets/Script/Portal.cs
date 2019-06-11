using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    [SerializeField]
    DialogueScriptable dayTeach;
    [SerializeField]
    AudioScriptableObject audioScriptableObject;
    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    bool isTeach;
    public Animator DialogueAnim;
    public GameObject Player;
    public GameObject HospitalPortal;
    public GameObject ParkPortal;
    public GameObject Park2Portal;
    public GameObject HousePortal;
    public GameObject MainCamare;
    public GameObject YesOrNo;

    public void Awake()
    {
        isTeach = false;
    }

    public void GoToWhr()
    {
        audioScriptableObject.btnSound = true;
        if (gameControllerScriptableObject.PortalPlace == "GoToHospital")
        {
            Debug.Log("GoToHospital");
            gameControllerScriptableObject.PlayerRoom = "Hospital";
            gameControllerScriptableObject.PortalPlace = "";
            Player.transform.position = HospitalPortal.transform.position;
            MainCamare.transform.position = new Vector3(-213.5f, 0, MainCamare.transform.position.z);
        }
        else if (gameControllerScriptableObject.PortalPlace == "GoToPark")
        {
            Debug.Log("GoToPark");
            gameControllerScriptableObject.PlayerRoom = "Park";
            gameControllerScriptableObject.PortalPlace = "";
            Player.transform.position = ParkPortal.transform.position;
            MainCamare.transform.position = new Vector3(-109, 0, MainCamare.transform.position.z);
            if (!isTeach)
            {
                isTeach = true;
                TriggerDialogue(dayTeach.dialogue);
                gameControllerScriptableObject.isPause = true;
            }
        }
        else if (gameControllerScriptableObject.PortalPlace == "GoToPark2")
        {
            Debug.Log("GoToPark2");
            gameControllerScriptableObject.PlayerRoom = "Park";
            gameControllerScriptableObject.PortalPlace = "";
            Player.transform.position = Park2Portal.transform.position;
            MainCamare.transform.position = new Vector3(109, 0, MainCamare.transform.position.z);
        }
        else if (gameControllerScriptableObject.PortalPlace == "GoToHouse")
        {
            Debug.Log("GoToHouse");
            gameControllerScriptableObject.PlayerRoom = "House";
            gameControllerScriptableObject.PortalPlace = "";
            Player.transform.position = HousePortal.transform.position;
            MainCamare.transform.position = new Vector3(223, 0, MainCamare.transform.position.z);
        }
    }

    public void DontGo()
    {
        gameControllerScriptableObject.isPause = false;
        audioScriptableObject.btnSound = true;
        gameControllerScriptableObject.PortalPlace = "";
        YesOrNo.SetActive(false);
        DialogueAnim.SetBool("IsOpen", false);        
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
