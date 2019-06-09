using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigEvent : MonoBehaviour {

    float ShowTimer;
    public BagItem bagItem;
    public Animator DigAnim;
    public Text takeItemText;
    public GameObject DigPic;
    public GameObject CarsUI;

    // Update is called once per frame
    void Update()
    {
        if (GameController.EventName == "Dig" && ShowTimer < 3)
        {
            DigAnim.SetBool("isDig", true);
            ShowTimer += Time.deltaTime;
            GameController.isPause = true;
        }
        else if (ShowTimer > 3 && GameController.EventName == "Dig")
        {
            Destroy(DigPic);
            takeItemText.text = "獲得玩具車";
            AudioController.takeItem = true;
            GameController.EventName = "";
            ShowTimer = 0;
            bagItem.AddItem("Cars");
            BagItem.isItem = true;
            CarsUI.SetActive(true);
            GameController.isPause = false;
        }
    }
}
