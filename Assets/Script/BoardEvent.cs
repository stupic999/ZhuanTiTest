using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardEvent : MonoBehaviour {

    public GameObject BoardDestroyable;

    public void isBoardEvent()
    {
        if (!GameController.isPause)
        {
            GameController.isEventOn = true;
            GameController.btnEvent = "BoardEvent";
            GameController.isBtnClick = true;
            Debug.Log("BoardClick");
            Destroy(BoardDestroyable);
        }
    }
}
