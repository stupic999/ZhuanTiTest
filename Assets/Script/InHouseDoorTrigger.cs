using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InHouseDoorTrigger : MonoBehaviour {

    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    public GameObject doorOpened;
    public GameObject doorClosed;

    public void Start()
    {
        doorClosed.SetActive(true);
        doorOpened.SetActive(false);
    }

    public void Update()
    {
        if (gameControllerScriptableObject.isOpenDoor != false)
        {
            doorClosed.SetActive(false);
            doorOpened.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && gameControllerScriptableObject.isOpenDoor != true)
        {
            gameControllerScriptableObject.btnEvent = "InHouseDoor";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            gameControllerScriptableObject.btnEvent = "";
        }
    }
}
