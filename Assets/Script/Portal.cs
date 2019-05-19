using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public GameObject Player;
    public GameObject HospitalPortal;
    public GameObject ParkPortal;
    public GameObject Park2Portal;
    public GameObject HousePortal;
    public GameObject MainCamare;
    public Animator DialogueAnim;
    public GameObject YesOrNo;

    public Dialogue teach;

    bool isTeach;

    public void GoToWhr()
    {
        AudioController.btnSound = true;
        if (GameController.PortalPlace == "GoToHospital")
        {
            Debug.Log("GoToHospital");
            GameController.PlayerRoom = "Hospital";
            GameController.PortalPlace = "";
            Player.transform.position = HospitalPortal.transform.position;
            MainCamare.transform.position = new Vector3(-213.5f, 0, MainCamare.transform.position.z);
        }
        else if (GameController.PortalPlace == "GoToPark")
        {
            Debug.Log("GoToPark");
            GameController.PlayerRoom = "Park";
            GameController.PortalPlace = "";
            Player.transform.position = ParkPortal.transform.position;
            MainCamare.transform.position = new Vector3(-109, 0, MainCamare.transform.position.z);
            if (!isTeach)
            {
                isTeach = true;
                TriggerDialogue(teach);
                GameController.isPause = true;
            }
        }
        else if (GameController.PortalPlace == "GoToPark2")
        {
            Debug.Log("GoToPark2");
            GameController.PlayerRoom = "Park";
            GameController.PortalPlace = "";
            Player.transform.position = Park2Portal.transform.position;
            MainCamare.transform.position = new Vector3(109, 0, MainCamare.transform.position.z);
        }
        else if (GameController.PortalPlace == "GoToHouse")
        {
            Debug.Log("GoToHouse");
            GameController.PlayerRoom = "House";
            GameController.PortalPlace = "";
            Player.transform.position = HousePortal.transform.position;
            MainCamare.transform.position = new Vector3(223, 0, MainCamare.transform.position.z);
        }
    }

    public void DontGo()
    {
        GameController.isPause = false;
        AudioController.btnSound = true;
        GameController.PortalPlace = "";
        YesOrNo.SetActive(false);
        DialogueAnim.SetBool("IsOpen", false);        
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
