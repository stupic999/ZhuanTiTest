using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigEvent : MonoBehaviour {

    public GameObject UI;
    public GameObject DigPic;
    public GameObject CarsUI;
    public Text takeItemText;
    float ShowTimer;

	// Update is called once per frame
	void Update () {
        if (GameController.EventName == "Dig" && ShowTimer<3)
        {
            UI.SetActive(true);
            ShowTimer += Time.deltaTime;
            GameController.isPause = true;
            Destroy(DigPic);
        }
        else if(ShowTimer>3 && GameController.EventName == "Dig")
        {
            takeItemText.text ="獲得玩具車";
            AudioController.takeItem = true;
            GameController.EventName = "";
            UI.SetActive(false);
            ShowTimer = 0;
            BagItem.Bag.Add("Cars");
            BagItem.isItem = true;
            CarsUI.SetActive(true);
            GameController.isPause = false;
        }
    }
}
