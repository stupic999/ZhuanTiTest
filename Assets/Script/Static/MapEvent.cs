using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEvent : MonoBehaviour {
 
    public GameObject CloseItem;
    public static bool MapOpen;

    public GameObject LeftBtn;
    public GameObject RightBtn;

    public GameObject Map1;
    public GameObject Map2;
    public GameObject Map3;
    public GameObject Map4;

    private void Update()
    {
        if (MapOpen != false)
            GameController.isPause = true;
        else
            GameController.isPause = false;

        if (GameController.MapCount == 1)
        {
            Map1.SetActive(true);
            Map2.SetActive(false);
        }
        else if (GameController.MapCount == 2)
        {
            Map1.SetActive(false);
            Map2.SetActive(true);
            Map3.SetActive(false);
        }
        else if (GameController.MapCount == 3)
        {
            Map2.SetActive(false);
            Map3.SetActive(true);
            Map4.SetActive(false);
        }
        else if (GameController.MapCount == 4)
        {
            Map3.SetActive(false);
            Map4.SetActive(true);
        }
        else
        {
            Map1.SetActive(false);
            Map2.SetActive(false);
            Map3.SetActive(false);
            Map4.SetActive(false);
        }

        if (GameController.MapCount > 1 && GameController.MapCount<=4)
        {
            LeftBtn.SetActive(true);
        }
        else
        {
            LeftBtn.SetActive(false);
        }

        if (GameController.MapCount < 4 && GameController.MapCount >=1)
        {
            RightBtn.SetActive(true);
        }
        else
        {
            RightBtn.SetActive(false);
        }
    }

    public void ClickLeftBtn()
    {
        AudioController.changeMap = true;
        GameController.MapCount -= 1;
        Debug.Log(GameController.MapCount);        
    }

    public void ClickRightBtn()
    {
        AudioController.changeMap = true;
        GameController.MapCount += 1;
        Debug.Log(GameController.MapCount);
    }

    public void isCloseBtn()
    {
        MapOpen = false;
        GameController.isPause = false;
        CloseItem.SetActive(false);
        AudioController.btnSound = true;
        GameController.MapCount = 0;

        Map1.SetActive(true);
        Map2.SetActive(false);
        Map3.SetActive(false);
        Map4.SetActive(false);
    }
}
