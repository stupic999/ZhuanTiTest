using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardEvent : MonoBehaviour {

    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    public GameObject BoardDestroyable;

    public void isBoardEvent()
    {
        if (!gameControllerScriptableObject.isPause)
        {
            gameControllerScriptableObject.isEventOn = true;
            gameControllerScriptableObject.btnEvent = "BoardEvent";
            gameControllerScriptableObject.isBtnClick = true;
            Debug.Log("BoardClick");
            Destroy(BoardDestroyable);
        }
    }
}
