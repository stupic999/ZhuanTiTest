using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEvent : MonoBehaviour {

    [SerializeField]
    AudioScriptableObject audioScriptableObject;
    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    public GameObject CloseItem;

    public GameObject LeftBtn;
    public GameObject RightBtn;

    public GameObject Map1;
    public GameObject Map2;
    public GameObject Map3;
    public GameObject Map4;

    private void Update()
    {
        if (gameControllerScriptableObject.MapOpen != false)
            gameControllerScriptableObject.isPause = true;
        else
            gameControllerScriptableObject.isPause = false;

        if (gameControllerScriptableObject.MapCount == 1)
        {
            Map1.SetActive(true);
            Map2.SetActive(false);
        }
        else if (gameControllerScriptableObject.MapCount == 2)
        {
            Map1.SetActive(false);
            Map2.SetActive(true);
            Map3.SetActive(false);
        }
        else if (gameControllerScriptableObject.MapCount == 3)
        {
            Map2.SetActive(false);
            Map3.SetActive(true);
            Map4.SetActive(false);
        }
        else if (gameControllerScriptableObject.MapCount == 4)
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

        if (gameControllerScriptableObject.MapCount > 1 && gameControllerScriptableObject.MapCount<=4)
        {
            LeftBtn.SetActive(true);
        }
        else
        {
            LeftBtn.SetActive(false);
        }

        if (gameControllerScriptableObject.MapCount < 4 && gameControllerScriptableObject.MapCount >=1)
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
        audioScriptableObject.changeMap = true;
        gameControllerScriptableObject.MapCount -= 1;
        Debug.Log(gameControllerScriptableObject.MapCount);        
    }

    public void ClickRightBtn()
    {
        audioScriptableObject.changeMap = true;
        gameControllerScriptableObject.MapCount += 1;
        Debug.Log(gameControllerScriptableObject.MapCount);
    }

    public void isCloseBtn()
    {
        gameControllerScriptableObject.MapOpen = false;
        gameControllerScriptableObject.isPause = false;
        CloseItem.SetActive(false);
        audioScriptableObject.btnSound = true;
        gameControllerScriptableObject.MapCount = 0;

        Map1.SetActive(true);
        Map2.SetActive(false);
        Map3.SetActive(false);
        Map4.SetActive(false);
    }
}
