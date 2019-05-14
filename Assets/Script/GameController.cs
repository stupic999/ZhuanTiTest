using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static bool isPause;
    public static bool isEventOn;
    public static bool isPuzzleEvent;

    public static int MapCount;

    public GameObject Photo;
    public GameObject PuzzleYet;
    public GameObject PuzzleDone;
    public GameObject PuzzleCamare;
    public GameObject BoardCamare;
    public GameObject BoardHint;
    public GameObject Player;
    public GameObject Grass1;
    public GameObject Grass2;
    public GameObject Grass3;
    public GameObject MapUI;
    public GameObject HospitalDoor;
    public GameObject ParkDoor;
    public GameObject PaperUI;
    public GameObject InHouseDoorBlock;
    public GameObject FishBait;
    public GameObject Bear;

    public Dialogue BoyDoneDialogue;
    public Dialogue BoyFailDialogue;
    public Dialogue DigDialogue;
    public Dialogue FishBaitFailDialogue;
    public Dialogue FishBaitDoneDialogue;
    public Dialogue PoolStartDialogue;
    public Dialogue PoolFailDialogue;
    public Dialogue PoolDoneDialogue;
    public Dialogue Grass1Dialogue;
    public Dialogue Grass2Dialogue;
    public Dialogue Grass3Dialogue;
    public Dialogue GrassDoneDialogue;
    public Dialogue LightCloseDialogue;
    public Dialogue LightOnDialogue;
    public Dialogue VaseInLightFailDialogue;
    public Dialogue VaseInLightDoneDialogue;
    public Dialogue VaseInDarkDoneDialogue;
    public Dialogue LadderFailDialogue;
    public Dialogue CupBoardDoneDialogue;
    public Dialogue CupBoardFailDialogue;
    public Dialogue PuzzleDoneDialogue;
    public Dialogue PuzzleFailDialogue;
    public Dialogue PuzzleStartDialogue;
    public Dialogue ShoesStartDialogue;
    public Dialogue ShoesDoneDialogue;
    public Dialogue ShoesFailDialogue;
    public Dialogue InHouseDoorFailDialogue;
    public Dialogue InHouseDoorDoneDialogue;
    public Dialogue BoardDoneDialogue;
    public Dialogue BoardFailDialogue;
    public Dialogue ComputerFailDialogue;
    public Dialogue ComputerDoneDialogue;
    public Dialogue ComputerStartDialogue;
    public Dialogue PhotoDialogue;
    public Dialogue PaperDoneDialogue;
    public Dialogue PaperFailDialogue;
    public Dialogue BearDialogue;
    public Dialogue BoardHintDone;

    public bool isOpenHospitalDoor;
    public bool isOpenParkDoor;

    public static string LoadingSceneName;
    public static string btnEvent;
    public static string EventName;

    int grassNum;

    public static bool isLoadingScene;
    public static bool isBtnClick;
    public static bool isTalkWithBoy;
    public static bool isSeePaper;
    public static bool isTakeFishBait;
    public static bool isCheckPool;
    public static bool isDigTreasure;
    public static bool isCheckGrass;
    public static bool isCloseLight;
    public static bool isCheckVaseInLight;
    public static bool isCheckVaseInDark;
    public static bool isCheckCupBoard;
    public static bool isDonePuzzle;
    public static bool isCheckShoes;
    public static bool isOpenDoor;
    public static bool isCheckBoard;
    public static bool isCheckComputer;
    public static bool isTakeBear;
    public static bool isBoardHint;

    public GameObject Btn;

    private void Start()
    {
        isPause = false;
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
    }

    public void ShowBtn()
    {
        if (isEventOn != true)
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
        else
        {
            Btn.SetActive(false);
        }
    }

    public void BtnEvent()
    {
        if (isBtnClick != false)
        {
            isPause = true;
            BoyEvent();
            HospitalDoorEvent();
            ParkDoorEvent();
            PaperEvent();
            FishBaitEvent();
            PoolEvent();
            DigEvent();
            GrassEvent();
            LightEvent();
            VaseEvent();
            CupBoardEvent();
            PuzzleEvent();
            ShoesEvent();
            InHouseDoorEvent();
            BoardEvent();
            ComputerEvent();
            PhotoEvent();
            LadderEvent();
            BoardEventOn();
            BearEvent();

            btnEvent = "";
            isBtnClick = false;
        }
    }

    // 按钮事件
    public void BoyEvent()
    {
        if (btnEvent == "Boy")
        {
            if (isTalkWithBoy != true)
            {
                isTalkWithBoy = true;
                Debug.Log("BoyDone");
                TriggerDialogue(BoyDoneDialogue);
            }
            else
            {
                Debug.Log("BoyFail");
                TriggerDialogue(BoyFailDialogue);
            }
        }
    }

    public void PaperEvent()
    {
        if (btnEvent == "Paper")
        {
            if (isSeePaper != true)
            {
                isSeePaper = true;
                MapUI.SetActive(true);
                MapCount = 1;
                Debug.Log("PaperDone");
                TriggerDialogue(PaperDoneDialogue);
                CloseBtn.MapOpen = true;
            }
            else if (isCheckPool != true)
            {
                MapCount = 1;
                MapUI.SetActive(true);
                Debug.Log("ShowMap");
                CloseBtn.MapOpen = true;
            }
            else
            {
                TriggerDialogue(PaperFailDialogue);
                Debug.Log("PaperFail");
            }
        }
    }

    public void FishBaitEvent()
    {
        if (btnEvent == "FishBait")
        {
            if (isSeePaper != false)
            {
                isTakeFishBait = true;
                Debug.Log("FishBaitDone");
                Destroy(FishBait);
                TriggerDialogue(FishBaitDoneDialogue);
                BagItem.Bag.Add("FishBait");
            }
            else
            {
                Debug.Log("FishBaitFail");
                TriggerDialogue(FishBaitFailDialogue);
            }
        }        
    }

    public void PoolEvent()
    {
        if (btnEvent == "Pool")
        {
            if (isCheckPool)
            {
                Debug.Log("PoolFail");
                TriggerDialogue(PoolFailDialogue);
            }
            else if (isTakeFishBait != false)
            {
                isCheckPool = true;
                BagItem.Bag.Add("Music");
                Debug.Log("PoolDone");
                BagItem.Bag.Remove("Pool");
                TriggerDialogue(PoolDoneDialogue);
            }
            else 
            {
                Debug.Log("PoolStart");
                TriggerDialogue(PoolStartDialogue);
            }
        }
    }

    public void DigEvent()
    {
        if (btnEvent == "Dig")
        {            
            isDigTreasure = true;
            EventName = "Dig";
            Debug.Log("DigDone");
            BagItem.Bag.Add("Cars");
        }
    }

    public void GrassEvent()
    {
        if (btnEvent == "Grass")
        {
            if (grassNum < 3)
            {
                grassNum++;
                Debug.Log("GrassNum " + grassNum);
                if (grassNum == 1)
                {
                    TriggerDialogue(Grass1Dialogue);
                    Grass1.transform.position = new Vector3(Grass1.transform.position.x + 5, Grass1.transform.position.y, Grass1.transform.position.z);
                }
                else if (grassNum == 2)
                {
                    TriggerDialogue(Grass2Dialogue);
                    Grass2.transform.position = new Vector3(Grass2.transform.position.x - 5, Grass2.transform.position.y, Grass2.transform.position.z);
                }
                else
                {
                    TriggerDialogue(Grass3Dialogue);
                    Grass3.transform.position = new Vector3(Grass3.transform.position.x + 5, Grass3.transform.position.y, Grass3.transform.position.z);
                }
            }
            else
            {
                isCheckGrass = true;
                Debug.Log("GrassDone");
                TriggerDialogue(GrassDoneDialogue);
                BagItem.Bag.Add("Clown");
            }
        }
    }

    public void LightEvent()
    {
        if (btnEvent == "Light")
        {
            isCloseLight = !isCloseLight;
            if (isCloseLight != false)
            {
                Photo.SetActive(false);
                Debug.Log("LightOn");
                TriggerDialogue(LightOnDialogue);
            }
            else
            {
                Photo.SetActive(true);
                Debug.Log("LightClose");
                TriggerDialogue(LightCloseDialogue);
            }            
        }
    }

    public void VaseEvent()
    {
        if (btnEvent == "Vase")
        {
            if (isCloseLight != true)
            {
                if (isCheckVaseInLight != true)
                {
                    isCheckVaseInLight = true;
                    Debug.Log("VaseInLightDone");
                    TriggerDialogue(VaseInLightDoneDialogue);
                    BagItem.Bag.Add("PuzzleVase");
                }
                else
                {
                    Debug.Log("VaseInLightFail");
                    TriggerDialogue(VaseInLightFailDialogue);
                }
            }
            else
            {
                    isCheckVaseInDark = true;
                    Debug.Log("VaseInDarkDone");
                    TriggerDialogue(VaseInDarkDoneDialogue);
            }
        }
    }

    public void CupBoardEvent()
    {
        if (btnEvent == "CupBoard")
        {
            if (isCheckCupBoard != true)
            {
                isCheckCupBoard = true;
                Debug.Log("CupBoardDone");
                TriggerDialogue(CupBoardDoneDialogue);
                BagItem.Bag.Add("PuzzleCupBoard");
            }
            else
            {
                Debug.Log("CupBoardFail");
                TriggerDialogue(CupBoardFailDialogue);
            }
        }
    }

    public void ShoesEvent()
    {
        if (btnEvent == "Shoes")
        {
            if (isCheckVaseInDark)
            {
                if (isCheckShoes != true)
                {
                    isCheckShoes = true;
                    Debug.Log("ShoesDone");
                    TriggerDialogue(ShoesDoneDialogue);
                    BagItem.Bag.Add("Key");
                }
                else
                {
                    Debug.Log("ShoesFail");
                    TriggerDialogue(ShoesFailDialogue);
                }
            }
            else
            {
                Debug.Log("ShoesStart");
                TriggerDialogue(ShoesStartDialogue);
            }
        }
    }

    public void InHouseDoorEvent()
    {
        if (btnEvent == "InHouseDoor")
        {
            if (isCheckShoes)
            {
                isOpenDoor = true;
                InHouseDoorBlock.SetActive(false);
                Debug.Log("DoorDone");
                TriggerDialogue(InHouseDoorDoneDialogue);
                BagItem.Bag.Remove("Key");
            }
            else
            {
                Debug.Log("DoorFail");
                TriggerDialogue(InHouseDoorFailDialogue);
            }
        }
    }

    public void BoardEvent()
    {
        if (btnEvent == "Board")
        {
            if (isCheckBoard != true)
            {
                isCheckBoard = true;
                Debug.Log("BoardDone");
                TriggerDialogue(BoardDoneDialogue);
                EventName = "BoardEvent";
                EventOn();
            }
            else
            {
                Debug.Log("BoardFail");
                TriggerDialogue(BoardFailDialogue);
            }
        }
    }

    public void BoardEventOn()
    {
        if (btnEvent == "BoardEvent")
        {
            isBoardHint = true;
            EventOff();
            Debug.Log("BoardDone2");
            TriggerDialogue(BoardHintDone);
        }
    }


    public void PuzzleEvent()
    {
        if (btnEvent == "Puzzle")
        {
            EventName = "PuzzleEvent";
            EventOn();
            if (isDonePuzzle)
            {
                Debug.Log("PuzzleFail");
                TriggerDialogue(PuzzleFailDialogue);
                EventOff();
            }
            else if (isCheckCupBoard && isCheckVaseInLight)
            {
                isPuzzleEvent = true;
                isDonePuzzle = true;
                Debug.Log("PuzzleDone");
                BagItem.Bag.Remove("PuzzleVase");
                BagItem.Bag.Remove("PuzzleCupBoard");
                TriggerDialogue(PuzzleDoneDialogue);
            }
            else
            {
                Debug.Log("PuzzleStart");
                TriggerDialogue(PuzzleStartDialogue);
                EventOff();
            }
        }
    }

    public void ComputerEvent()
    {
        if (btnEvent == "Computer")
        {
            if (isCheckComputer != true)
            {
                if (isCheckBoard != false)
                {
                    isCheckComputer = true;
                    Debug.Log("ConputerDone");
                    TriggerDialogue(ComputerDoneDialogue);
                }
                else
                {
                    Debug.Log("ComputerStart");
                    TriggerDialogue(ComputerStartDialogue);
                }
            }
            else
            {
                Debug.Log("ComputerFail");
                TriggerDialogue(ComputerFailDialogue);
            }            
        }
    }

    public void PhotoEvent()
    {
        if (btnEvent == "Photo")
        {
            Debug.Log("PhotoDone");
            TriggerDialogue(PhotoDialogue);
        }
    }

    public void BearEvent()
    {
        if (btnEvent == "Bear")
        {
            Debug.Log("BearDone");
            isTakeBear = true;
            TriggerDialogue(BearDialogue);
            Destroy(Bear);
        }
    }

    public void LadderEvent()
    {
        if (btnEvent == "Ladder")
        {
            Debug.Log("LadderDone");
            TriggerDialogue(LadderFailDialogue);
        }
    }

    public void HospitalDoorEvent()
    {
        if (btnEvent == "HospitalDoor")
        {
            Player.transform.position = new Vector3(ParkDoor.transform.position.x + 5, ParkDoor.transform.position.y, ParkDoor.transform.position.z);
            Debug.Log("HospitalDoorDone");
            isPause = false;
        }
    }

    public void ParkDoorEvent()
    {
        if (btnEvent == "ParkDoor")
        {
            Player.transform.position = new Vector3(HospitalDoor.transform.position.x + 5, HospitalDoor.transform.position.y, HospitalDoor.transform.position.z);
            Debug.Log("ParkDoorDone");
            isPause = false;
        }
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void EventOn()
    {
        isEventOn = true;
        Player.SetActive(false);
        if (EventName == "BoardEvent")
        {
            BoardHint.SetActive(true);
            BoardCamare.SetActive(true);
        }
        if (EventName == "PuzzleEvent")
        {
            PuzzleCamare.SetActive(true);
            if (isDonePuzzle)
            {
                PuzzleDone.SetActive(true);
            }
            else
            {
                PuzzleYet.SetActive(true);
            }
        }
    }

    public void EventOff()
    {
        isEventOn = false;
    }
}
