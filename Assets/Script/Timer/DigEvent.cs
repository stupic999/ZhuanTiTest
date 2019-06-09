using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigEvent : MonoBehaviour {

    [SerializeField]
    TimerScriptableObject timerScriptableObject;
    [SerializeField]
    AudioScriptableObject audioScriptableObject;
    public BagItem bagItem;
    public Animator DigAnim;
    public Text takeItemText;
    public GameObject DigPic;
    public GameObject CarsUI;

    // Update is called once per frame
    void Update()
    {
        if (GameController.EventName == "Dig" && timerScriptableObject.digEventTimer < 3)
        {
            DigAnim.SetBool("isDig", true);
            timerScriptableObject.digEventTimer += Time.deltaTime;
            GameController.isPause = true;
        }
        else if (timerScriptableObject.digEventTimer > 3 && GameController.EventName == "Dig")
        {
            Destroy(DigPic);
            takeItemText.text = "獲得玩具車";
            audioScriptableObject.takeItem = true;
            GameController.EventName = "";
            timerScriptableObject.digEventTimer = 0;
            bagItem.AddItem("Cars");
            BagItem.isItem = true;
            CarsUI.SetActive(true);
            GameController.isPause = false;
        }
    }
}
