using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField]
    AudioScriptableObject audioScriptableObject;
    public BagItem bagItem;

    public static string PlayerRoom = "Hospital";
    public static string PortalPlace;
    public static bool isPause;
    public static bool isEventOn;
    public static bool isPuzzleEvent;
    public static bool allDone;
    public static int winCount;

    public static bool playerDie;

    public GameObject mainCamare;

    public Text takeItemText;

    public static int MapCount;

    public GameObject FishBaitUI;
    public GameObject KeyUI;
    public GameObject BearUI;
    public GameObject ClownUI;
    public GameObject PuzzleVaseUI;
    public GameObject PuzzleCupBoardUI;
    public GameObject MusicUI;

    public GameObject computerUI;
    public GameObject computerEvent;
    public GameObject PuzzleYet;
    public GameObject PuzzleDone;
    public GameObject PuzzleCamare;
    public GameObject BoardCamare;
    public GameObject BoardBtn;
    public GameObject BoardPaper;
    public GameObject Player;
    public GameObject Grass1;
    public GameObject Grass2;
    public GameObject Grass3;
    public GameObject MapUI;
    public GameObject PaperUI;
    public GameObject InHouseDoorBlock;
    public GameObject FishBait;
    public GameObject Bear;
    public GameObject HouseBgLightYet;
    public GameObject HouseBgLightDone;
    public GameObject HouseBgNightYet;
    public GameObject HouseBgNightDone;

    public Dialogue WinDialogue;

    public Dialogue BoyDoneDialogue;
    public Dialogue FishBaitStartDialogue;
    public Dialogue PoolStartDialogue;
    public Dialogue Grass1Dialogue;
    public Dialogue Grass2Dialogue;
    public Dialogue Grass3Dialogue;
    public Dialogue LadderFailDialogue;
    public Dialogue PuzzleDoneDialogue;
    public Dialogue PuzzleHalfDialogue;
    public Dialogue PuzzleStartDialogue;
    public Dialogue InHouseFailDoorDialogue;
    public Dialogue BoardStartDialogue;
    public Dialogue ComputerStartDialogue;
    public Dialogue BoardHintDone;

    public static string btnEvent;
    public static string EventName;

    int grassNum;

    public static bool isBtnClick;
    public static bool isTalkWithBoy;
    public static bool isSeePaper;
    public static bool isTakeFishBait;
    public static bool isCheckPool;
    public static bool isDigTreasure;
    public static bool isCheckGrass;
    public static bool isCheckVase;
    public static bool isCheckCupBoard;
    public static bool isDonePuzzle;
    public static bool isCheckShoes;
    public static bool isOpenDoor;
    public static bool isCheckBoard;
    public static bool isCheckComputer;
    public static bool isTakeBear;
    public static bool isBoardHint;
    public static bool isCheckLadder;

    public GameObject Btn;

    private void Start()
    {
        btnEvent = "Boy";
        isBtnClick = true;

        isPause = false;
        // 把全部bool设定预设值
    }

    private void Update()
    {
        // 顯示按鈕
        ShowBtn();

        // 按鈕點擊觸發事件
        BtnEvent();

        if (isTakeBear && isDonePuzzle && isCheckComputer && isCheckPool && isDigTreasure && isCheckGrass)
        {
            allDone = true;
        }
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
            if (btnEvent == "")
            {
                isPause = false;
            }
            BoyEvent();
            PaperEvent();
            FishBaitEvent();
            PoolEvent();
            DigEvent();
            GrassEvent();
            VaseEvent();
            CupBoardEvent();
            PuzzleEvent();
            ShoesEvent();
            InHouseDoorEvent();
            BoardEvent();
            ComputerEvent();
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
            if (!isTalkWithBoy)
            {
                isTalkWithBoy = true;
                Debug.Log("BoyDone");
                TriggerDialogue(BoyDoneDialogue);
            }
        }
    }

    public void PaperEvent()
    {
        if (btnEvent == "Paper" && !isCheckPool)
        {
            isSeePaper = true;
            MapUI.SetActive(true);
            MapCount = 1;
            Debug.Log("PaperDone");
            MapEvent.MapOpen = true;
        }
    }

    public void FishBaitEvent()
    {
        if (btnEvent == "FishBait")
        {
            if (isSeePaper)
            {
                isTakeFishBait = true;
                Debug.Log("FishBaitDone");
                Destroy(FishBait);
                bagItem.AddItem("FishBait");
                FishBaitUI.SetActive(true);
                audioScriptableObject.takeItem = true;
                takeItemText.text = "獲得麵包";
                isPause = false;
            }
            else
            {
                Debug.Log("FishBaitStart");
                TriggerDialogue(FishBaitStartDialogue);
            }
        }        
    }

    public void PoolEvent()
    {
        if (btnEvent == "Pool")
        {
            if (isTakeFishBait)
            {
                isCheckPool = true;
                bagItem.RemoveItem("FishBait");
                bagItem.AddItem("Music");
                MusicUI.SetActive(true);
                Debug.Log("PoolDone");
                isPause = false;
                audioScriptableObject.takeItem = true;
                takeItemText.text = "獲得樂器";
                if (allDone && winCount == 0)
                {
                    TriggerDialogue(WinDialogue);
                    winCount++;
                    isPause = true;
                }
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
            audioScriptableObject.digSand = true;
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
                    Grass1.transform.position = new Vector3(Grass1.transform.position.x -2, Grass1.transform.position.y, Grass1.transform.position.z);
                }
                else if (grassNum == 2)
                {
                    TriggerDialogue(Grass2Dialogue);
                    Grass2.transform.position = new Vector3(Grass2.transform.position.x -2, Grass2.transform.position.y, Grass2.transform.position.z);
                }
                else
                {
                    TriggerDialogue(Grass3Dialogue);
                    Grass3.transform.position = new Vector3(Grass3.transform.position.x +2, Grass3.transform.position.y, Grass3.transform.position.z);
                }
            }
            else
            {
                isCheckGrass = true;
                Debug.Log("GrassDone");
                bagItem.AddItem("Clown");
                ClownUI.SetActive(true);
                audioScriptableObject.takeItem = true;
                isPause = false;
                takeItemText.text = "獲得驚嚇箱";
                if (allDone && winCount == 0)
                {
                    TriggerDialogue(WinDialogue);
                    winCount++;
                    isPause = true;
                }
            }
        }
    }

    public void VaseEvent()
    {
        if (btnEvent == "Vase")
        {
            isCheckVase = true;
            Debug.Log("VaseInDone");
            bagItem.AddItem("PuzzleVase");
            PuzzleVaseUI.SetActive(true);
            isPause = false;
            audioScriptableObject.takeItem = true;
            takeItemText.text = "獲得拼圖(下)";
        }
    }

    public void CupBoardEvent()
    {
        if (btnEvent == "CupBoard")
        {
            if (!isCheckCupBoard)
            {
                isCheckCupBoard = true;
                Debug.Log("CupBoardDone");
                bagItem.AddItem("PuzzleCupBoard");
                PuzzleCupBoardUI.SetActive(true);
                audioScriptableObject.takeItem = true;
                isPause = false;
                takeItemText.text = "獲得拼圖(上)";
            }
        }
    }

    public void ShoesEvent()
    {
        if (btnEvent == "Shoes")
        {
            if (!isCheckShoes)
            {
                isCheckShoes = true;
                Debug.Log("ShoesDone");
                bagItem.AddItem("Key");
                KeyUI.SetActive(true);
                audioScriptableObject.takeItem = true;
                isPause = false;
                takeItemText.text = "獲得門鑰匙";
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
                bagItem.RemoveItem("Key");
                audioScriptableObject.openDoor = true;
                isPause = false;
            }
            else
            {
                Debug.Log("DoorFail");
                TriggerDialogue(InHouseFailDoorDialogue);
            }
        }
    }

    public void BoardEvent()
    {
        if (btnEvent == "Board")
        {
            if (!isCheckBoard)
            {
                isCheckBoard = true;
                Debug.Log("BoardStart");
                TriggerDialogue(BoardStartDialogue);
                EventName = "BoardEvent";
                EventOn();
            }
        }
    }

    public void BoardEventOn()
    {
        if (btnEvent == "BoardEvent")
        {
            EventOff();
            isBoardHint = true;
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

            if (isCheckCupBoard && isCheckVase)
            {
                EventName = "PuzzleEvent2";
                if (ClockTimer.isNight)
                {
                    HouseBgNightDone.SetActive(true);
                    HouseBgNightYet.SetActive(false);
                }
                else
                {
                    HouseBgLightDone.SetActive(true);
                    HouseBgLightYet.SetActive(false);
                }
                isPuzzleEvent = true;
                Debug.Log("PuzzleDone");
                bagItem.RemoveItem("PuzzleVase");
                bagItem.RemoveItem("PuzzleCupBoard");
                TriggerDialogue(PuzzleDoneDialogue);
                audioScriptableObject.takeItem = true;
            }
            else if (isCheckCupBoard || isCheckVase)
            {
                Debug.Log("PuzzleHalf");
                TriggerDialogue(PuzzleHalfDialogue);
            }
            else
            {
                Debug.Log("PuzzleStart");
                TriggerDialogue(PuzzleStartDialogue);
            }
        }
    }

    public void ComputerEvent()
    {
        if (btnEvent == "Computer")
        {
            if (isCheckBoard)
            {
                EventName = "ComputerEvent";
                Debug.Log("ComputerEvent");
                EventOn();
                audioScriptableObject.openComputer = true;
                isPause = false;
            }
            else
            {
                Debug.Log("ComputerStart");
                TriggerDialogue(ComputerStartDialogue);
            }         
        }
    }

    public void CloseComputer()
    {
        if (!isPause)
        {
            computerUI.SetActive(false);
            computerEvent.SetActive(false);
            Player.SetActive(true);
            EventOff();
        }
    }

    public void BearEvent()
    {
        if (btnEvent == "Bear")
        {
            Debug.Log("BearDone");
            isTakeBear = true;
            bagItem.AddItem("Bear");
            BearUI.SetActive(true);
            Destroy(Bear);
            audioScriptableObject.takeItem = true;
            isPause = false;
            takeItemText.text = "獲得小熊玩偶";
            if (allDone && winCount == 0)
            {
                TriggerDialogue(WinDialogue);
                winCount++;
                isPause = true;
            }
        }
    }

    public void LadderEvent()
    {
        if (btnEvent == "Ladder")
        {
            Debug.Log("LadderDone");
            isCheckLadder = true;
            TriggerDialogue(LadderFailDialogue);
        }
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void EventOn()
    {
        mainCamare.SetActive(false);
        isEventOn = true;
        Player.SetActive(false);
        
        if (EventName == "BoardEvent")
        {
            BoardBtn.SetActive(true);
            BoardCamare.SetActive(true);
            BoardPaper.SetActive(false);
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
        if (EventName == "ComputerEvent")
        {
            computerEvent.SetActive(true);
            computerUI.SetActive(true);            
        }
    }

    public void EventOff()
    {
        isEventOn = false;
    }
}
