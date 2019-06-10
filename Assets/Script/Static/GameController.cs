using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField]
    AudioScriptableObject audioScriptableObject;
    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    int grassNum;
    public BagItem bagItem;
    public GameObject mainCamare;
    public Text takeItemText;
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
    public GameObject Btn;

    void Start()
    {
        gameControllerScriptableObject.btnEvent = "Boy";
        gameControllerScriptableObject.isTalkWithBoy = false;
        gameControllerScriptableObject.isBtnClick = true;
        // 把全部bool设定预设值
    }

    void Update()
    {
        // 顯示按鈕
        ShowBtn();

        // 按鈕點擊觸發事件
        BtnEvent();

        if (gameControllerScriptableObject.isTakeBear && gameControllerScriptableObject.isDonePuzzle && gameControllerScriptableObject.isCheckComputer && gameControllerScriptableObject.isCheckPool && gameControllerScriptableObject.isDigTreasure && gameControllerScriptableObject.isCheckGrass)
        {
            gameControllerScriptableObject.allDone = true;
        }
    }

    public void ShowBtn()
    {
        if (gameControllerScriptableObject.isEventOn != true)
        {
            if (gameControllerScriptableObject.btnEvent != "")
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
        if (gameControllerScriptableObject.isBtnClick != false)
        {
            if (gameControllerScriptableObject.btnEvent == "")
            {
                gameControllerScriptableObject.isPause = false;
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
            gameControllerScriptableObject.btnEvent = "";
            gameControllerScriptableObject.isBtnClick = false;
        }
    }

    // 按钮事件
    public void BoyEvent()
    {
        if (gameControllerScriptableObject.btnEvent == "Boy")
        {
            if (!gameControllerScriptableObject.isTalkWithBoy)
            {
                gameControllerScriptableObject.isTalkWithBoy = true;
                Debug.Log("BoyDone");
                TriggerDialogue(BoyDoneDialogue);
            }
        }
    }

    public void PaperEvent()
    {
        if (gameControllerScriptableObject.btnEvent == "Paper" && !gameControllerScriptableObject.isCheckPool)
        {
            gameControllerScriptableObject.isSeePaper = true;
            MapUI.SetActive(true);
            gameControllerScriptableObject.MapCount = 1;
            Debug.Log("PaperDone");
            gameControllerScriptableObject.MapOpen = true;
        }
    }

    public void FishBaitEvent()
    {
        if (gameControllerScriptableObject.btnEvent == "FishBait")
        {
            if (gameControllerScriptableObject.isSeePaper)
            {
                gameControllerScriptableObject.isTakeFishBait = true;
                Debug.Log("FishBaitDone");
                Destroy(FishBait);
                bagItem.AddItem("FishBait");
                FishBaitUI.SetActive(true);
                audioScriptableObject.takeItem = true;
                takeItemText.text = "獲得麵包";
                gameControllerScriptableObject.isPause = false;
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
        if (gameControllerScriptableObject.btnEvent == "Pool")
        {
            if (gameControllerScriptableObject.isTakeFishBait)
            {
                gameControllerScriptableObject.isCheckPool = true;
                bagItem.RemoveItem("FishBait");
                bagItem.AddItem("Music");
                MusicUI.SetActive(true);
                Debug.Log("PoolDone");
                gameControllerScriptableObject.isPause = false;
                audioScriptableObject.takeItem = true;
                takeItemText.text = "獲得樂器";
                if (gameControllerScriptableObject.allDone && gameControllerScriptableObject.winCount == 0)
                {
                    TriggerDialogue(WinDialogue);
                    gameControllerScriptableObject.winCount++;
                    gameControllerScriptableObject.isPause = true;
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
        if (gameControllerScriptableObject.btnEvent == "Dig")
        {
            gameControllerScriptableObject.isDigTreasure = true;
            gameControllerScriptableObject.EventName = "Dig";
            Debug.Log("DigDone");
            audioScriptableObject.digSand = true;
        }
    }

    public void GrassEvent()
    {
        if (gameControllerScriptableObject.btnEvent == "Grass")
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
                gameControllerScriptableObject.isCheckGrass = true;
                Debug.Log("GrassDone");
                bagItem.AddItem("Clown");
                ClownUI.SetActive(true);
                audioScriptableObject.takeItem = true;
                gameControllerScriptableObject.isPause = false;
                takeItemText.text = "獲得驚嚇箱";
                if (gameControllerScriptableObject.allDone && gameControllerScriptableObject.winCount == 0)
                {
                    TriggerDialogue(WinDialogue);
                    gameControllerScriptableObject.winCount++;
                    gameControllerScriptableObject.isPause = true;
                }
            }
        }
    }

    public void VaseEvent()
    {
        if (gameControllerScriptableObject.btnEvent == "Vase")
        {
            gameControllerScriptableObject.isCheckVase = true;
            Debug.Log("VaseInDone");
            bagItem.AddItem("PuzzleVase");
            PuzzleVaseUI.SetActive(true);
            gameControllerScriptableObject.isPause = false;
            audioScriptableObject.takeItem = true;
            takeItemText.text = "獲得拼圖(下)";
        }
    }

    public void CupBoardEvent()
    {
        if (gameControllerScriptableObject.btnEvent == "CupBoard")
        {
            if (!gameControllerScriptableObject.isCheckCupBoard)
            {
                gameControllerScriptableObject.isCheckCupBoard = true;
                Debug.Log("CupBoardDone");
                bagItem.AddItem("PuzzleCupBoard");
                PuzzleCupBoardUI.SetActive(true);
                audioScriptableObject.takeItem = true;
                gameControllerScriptableObject.isPause = false;
                takeItemText.text = "獲得拼圖(上)";
            }
        }
    }

    public void ShoesEvent()
    {
        if (gameControllerScriptableObject.btnEvent == "Shoes")
        {
            if (!gameControllerScriptableObject.isCheckShoes)
            {
                gameControllerScriptableObject.isCheckShoes = true;
                Debug.Log("ShoesDone");
                bagItem.AddItem("Key");
                KeyUI.SetActive(true);
                audioScriptableObject.takeItem = true;
                gameControllerScriptableObject.isPause = false;
                takeItemText.text = "獲得門鑰匙";
            }
        }
    }

    public void InHouseDoorEvent()
    {
        if (gameControllerScriptableObject.btnEvent == "InHouseDoor")
        {
            if (gameControllerScriptableObject.isCheckShoes)
            {
                gameControllerScriptableObject.isOpenDoor = true;
                InHouseDoorBlock.SetActive(false);
                Debug.Log("DoorDone");
                bagItem.RemoveItem("Key");
                audioScriptableObject.openDoor = true;
                gameControllerScriptableObject.isPause = false;
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
        if (gameControllerScriptableObject.btnEvent == "Board")
        {
            if (!gameControllerScriptableObject.isCheckBoard)
            {
                gameControllerScriptableObject.isCheckBoard = true;
                Debug.Log("BoardStart");
                TriggerDialogue(BoardStartDialogue);
                gameControllerScriptableObject.EventName = "BoardEvent";
                EventOn();
            }
        }
    }

    public void BoardEventOn()
    {
        if (gameControllerScriptableObject.btnEvent == "BoardEvent")
        {
            EventOff();
            gameControllerScriptableObject.isBoardHint = true;
            Debug.Log("BoardDone2");
            TriggerDialogue(BoardHintDone);
        }
    }


    public void PuzzleEvent()
    {
        if (gameControllerScriptableObject.btnEvent == "Puzzle")
        {
            gameControllerScriptableObject.EventName = "PuzzleEvent";
            EventOn();

            if (gameControllerScriptableObject.isCheckCupBoard && gameControllerScriptableObject.isCheckVase)
            {
                gameControllerScriptableObject.EventName = "PuzzleEvent2";
                if (gameControllerScriptableObject.isNight)
                {
                    HouseBgNightDone.SetActive(true);
                    HouseBgNightYet.SetActive(false);
                }
                else
                {
                    HouseBgLightDone.SetActive(true);
                    HouseBgLightYet.SetActive(false);
                }
                gameControllerScriptableObject.isPuzzleEvent = true;
                Debug.Log("PuzzleDone");
                bagItem.RemoveItem("PuzzleVase");
                bagItem.RemoveItem("PuzzleCupBoard");
                TriggerDialogue(PuzzleDoneDialogue);
                audioScriptableObject.takeItem = true;
            }
            else if (gameControllerScriptableObject.isCheckCupBoard || gameControllerScriptableObject.isCheckVase)
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
        if (gameControllerScriptableObject.btnEvent == "Computer")
        {
            if (gameControllerScriptableObject.isCheckBoard)
            {
                gameControllerScriptableObject.EventName = "ComputerEvent";
                Debug.Log("ComputerEvent");
                EventOn();
                audioScriptableObject.openComputer = true;
                gameControllerScriptableObject.isPause = false;
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
        if (!gameControllerScriptableObject.isPause)
        {
            computerUI.SetActive(false);
            computerEvent.SetActive(false);
            Player.SetActive(true);
            EventOff();
        }
    }

    public void BearEvent()
    {
        if (gameControllerScriptableObject.btnEvent == "Bear")
        {
            Debug.Log("BearDone");
            gameControllerScriptableObject.isTakeBear = true;
            bagItem.AddItem("Bear");
            BearUI.SetActive(true);
            Destroy(Bear);
            audioScriptableObject.takeItem = true;
            gameControllerScriptableObject.isPause = false;
            takeItemText.text = "獲得小熊玩偶";
            if (gameControllerScriptableObject.allDone && gameControllerScriptableObject.winCount == 0)
            {
                TriggerDialogue(WinDialogue);
                gameControllerScriptableObject.winCount++;
                gameControllerScriptableObject.isPause = true;
            }
        }
    }

    public void LadderEvent()
    {
        if (gameControllerScriptableObject.btnEvent == "Ladder")
        {
            Debug.Log("LadderDone");
            gameControllerScriptableObject.isCheckLadder = true;
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
        gameControllerScriptableObject.isEventOn = true;
        Player.SetActive(false);
        
        if (gameControllerScriptableObject.EventName == "BoardEvent")
        {
            BoardBtn.SetActive(true);
            BoardCamare.SetActive(true);
            BoardPaper.SetActive(false);
        }
        if (gameControllerScriptableObject.EventName == "PuzzleEvent")
        {
            PuzzleCamare.SetActive(true);
            if (gameControllerScriptableObject.isDonePuzzle)
            {
                PuzzleDone.SetActive(true);
            }
            else
            {
                PuzzleYet.SetActive(true);
            }
        }
        if (gameControllerScriptableObject.EventName == "ComputerEvent")
        {
            computerEvent.SetActive(true);
            computerUI.SetActive(true);            
        }
    }

    public void EventOff()
    {
        gameControllerScriptableObject.isEventOn = false;
    }
}
