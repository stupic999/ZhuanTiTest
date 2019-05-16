using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HACK : MonoBehaviour {

    public GameObject Player;
    public GameObject MainCamare;
    public GameObject HospitalPortal;
    public GameObject ParkPortal;
    public GameObject Park2Portal;
    public GameObject HousePortal;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Player.transform.position = new Vector3(Player.transform.position.x - 10, Player.transform.position.y, Player.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Player.transform.position = new Vector3(Player.transform.position.x + 10, Player.transform.position.y, Player.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameController.PortalPlace = "GoToHospital";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameController.PortalPlace = "GoToPark";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameController.PortalPlace = "GoToPark2";
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameController.PortalPlace = "GoToHouse";
        }
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
}
