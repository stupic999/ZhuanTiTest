using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject Player;
    public GameObject HospitalDoor;
    public GameObject ParkDoor;
    public GameObject PaperUI;

    public bool isOpenHospitalDoor;
    public bool isOpenParkDoor;

    public static string LoadingSceneName;
    public static string btnEvent;

    int grassNum;

    public static bool isLoadingScene;
    public static bool isBtnClick;
    public static bool isTalkWithBoy;
    public static bool isSeePaper;
    public static bool isTakeFishBait;
    public static bool isCheckPool;
    public static bool isDigTreasure;
    public static bool isCheckGrass;

    public GameObject Btn;

    private void Start()
    {
        isBtnClick = false;
        isLoadingScene = false;
        LoadingSceneName = "";
        // 把全部bool设定预设值
        btnEvent="";
    }

    private void Update()
    {
        // 顯示按鈕
        ShowBtn();

        // 按鈕點擊觸發事件
        BtnEvent();

        // 传送
        GoToPark();
        GoToHospital();
    }

    public void ShowBtn()
    {
        if (btnEvent != "")
        {
            Btn.SetActive(true);
        }
        else
        {
            Btn.SetActive(false);
        }
    }

    public void BtnEvent()
    {
        if (isBtnClick != false)
        {
            BoyEvent();
            HospitalDoorEvent();
            ParkDoorEvent();
            PaperEvent();
            FishBaitEvent();
            PoolEvent();
            DigEvent();
            GrassEvent();

            btnEvent = "";
            isBtnClick = false;
        }
    }

    // 按钮事件
    public void BoyEvent()
    {
        if (btnEvent == "Boy")
        {
            isTalkWithBoy = true;
            Debug.Log("BoyDone");
        }
    }

    public void PaperEvent()
    {
        if (btnEvent == "Paper")
        {
            isSeePaper = true;
            Debug.Log("PaperDone");
        }
    }

    public void FishBaitEvent()
    {
        if (btnEvent == "FishBait")
        {
            isTakeFishBait = true;
            Debug.Log("FishBaitDone");
        }        
    }

    public void PoolEvent()
    {
        if (btnEvent == "Pool")
        {
            isCheckPool = true;
            Debug.Log("PoolDone");
        }
    }

    public void DigEvent()
    {
        if (btnEvent == "Dig")
        {
            isDigTreasure = true;
            Debug.Log("DigDone");
        }
    }

    public void GrassEvent()
    {
        if (btnEvent == "Grass")
        {
            if (grassNum < 3)
            {
                grassNum++;
                Debug.Log("GrassNum "+grassNum);
            }
            else
            {
                isCheckGrass = true;
                Debug.Log("GrassDone");
            }
        }
    }

    public void HospitalDoorEvent()
    {
        if (btnEvent == "HospitalDoor")
        {
            isOpenHospitalDoor = true;
            Debug.Log("HospitalDoorDone");
        }
    }

    public void ParkDoorEvent()
    {
        if (btnEvent == "ParkDoor")
        {
            isOpenParkDoor = true;
            Debug.Log("ParkDoorDone");
        }
    }

    // 传送
    public void GoToPark()
    {
        if (isOpenHospitalDoor != false)
        {
            isOpenHospitalDoor = false;
            Player.transform.position = new Vector3(ParkDoor.transform.position.x + 5, ParkDoor.transform.position.y, ParkDoor.transform.position.z);            
        }
    }

    public void GoToHospital()
    {
        if (isOpenParkDoor != false)
        {
            isOpenParkDoor = false;
            Player.transform.position = new Vector3(HospitalDoor.transform.position.x + 5, HospitalDoor.transform.position.y, HospitalDoor.transform.position.z);
        }
    }
}
