using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBtn : MonoBehaviour {

    public GameObject CloseItem;
    public static bool MapOpen;

    public void Update()
    {
        if (MapOpen != false)
            GameController.isPause = true;
        else
            GameController.isPause = false;
    }

    public void isCloseBtn()
    {
        MapOpen = false;
        GameController.isPause = false;
        CloseItem.SetActive(false);
        AudioController.btnSound = true;
        GameController.MapCount = 0;
    }
}
