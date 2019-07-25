using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField]
    DialogueScriptable winDialogue;
    [SerializeField]
    DialogueScriptable boyDoneDialogue;
    [SerializeField]
    DialogueScriptable fishBaitStartDialogue;
    [SerializeField]
    DialogueScriptable poolStartDialogue;
    [SerializeField]
    DialogueScriptable grass1Dialogue;
    [SerializeField]
    DialogueScriptable grass2Dialogue;
    [SerializeField]
    DialogueScriptable grass3Dialogue;
    [SerializeField]
    DialogueScriptable ladderFailDialogue;
    [SerializeField]
    DialogueScriptable puzzleDoneDialogue;
    [SerializeField]
    DialogueScriptable puzzleHalfDialogue;
    [SerializeField]
    DialogueScriptable puzzleStartDialogue;
    [SerializeField]
    DialogueScriptable inHouseFailDoorDialogue;
    [SerializeField]
    DialogueScriptable boardStartDialogue;
    [SerializeField]
    DialogueScriptable computerStartDialogue;
    [SerializeField]
    DialogueScriptable boardHintDone;
    [SerializeField]
    AudioScriptableObject audioScriptableObject;
    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    int grassNum;
    public BagItem bagItem;
    public Text takeItemText;
    public GameObject mainCamare;
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
    public GameObject Btn;

    private void Awake()
    {
        grassNum = 0;
        takeItemText.text = "";

        // GameControllerScriptObject的預設值
        gameControllerScriptableObject.winCount = 0 ;
        gameControllerScriptableObject.MapCount=0;
        gameControllerScriptableObject.MapOpen=false;
        gameControllerScriptableObject.isPause=false;
        gameControllerScriptableObject.isEventOn = false;
        gameControllerScriptableObject.isPuzzleEvent = false;
        gameControllerScriptableObject.allDone = false;
        gameControllerScriptableObject.playerDie = false;
        gameControllerScriptableObject.isBtnClick = false;
        gameControllerScriptableObject.isTalkWithBoy = false;
        gameControllerScriptableObject.isSeeBread = false;
        gameControllerScriptableObject.isSeePaper = false;
        gameControllerScriptableObject.isTakeFishBait = false;
        gameControllerScriptableObject.isCheckPool = false;
        gameControllerScriptableObject.isDigTreasure = false;
        gameControllerScriptableObject.isCheckGrass = false;
        gameControllerScriptableObject.isCheckVase = false;
        gameControllerScriptableObject.isCheckCupBoard = false;
        gameControllerScriptableObject.isDonePuzzle = false;
        gameControllerScriptableObject.isCheckShoes = false;
        gameControllerScriptableObject.isOpenDoor = false;
        gameControllerScriptableObject.isCheckBoard = false;
        gameControllerScriptableObject.isCheckComputer = false;
        gameControllerScriptableObject.isTakeBear = false;
        gameControllerScriptableObject.isBoardHint = false;
        gameControllerScriptableObject.isCheckLadder = false;
        gameControllerScriptableObject.isNight = false;
        gameControllerScriptableObject.isGhost = false;
        gameControllerScriptableObject.ghostDie = false;
        gameControllerScriptableObject.isOpenLight = false;
        gameControllerScriptableObject.btnEvent = "";
        gameControllerScriptableObject.EventName = "";
        gameControllerScriptableObject.PlayerRoom = "Hospital";
        gameControllerScriptableObject.PortalPlace = "";
        gameControllerScriptableObject.PlayerFace = "L";
    }

    void Start()
    {
        gameControllerScriptableObject.btnEvent = "Boy";
        gameControllerScriptableObject.isBtnClick = true;
    }

    void Update()
    {
        // 顯示按鈕
        ShowBtn();

        // 按鈕點擊觸發事件
        BtnEvent();
        Win();
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
                TriggerDialogue(boyDoneDialogue.dialogue);
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
                gameControllerScriptableObject.isSeeBread = true;
                TriggerDialogue(fishBaitStartDialogue.dialogue);
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
                Win();
            }
            else 
            {
                Debug.Log("PoolStart");
                TriggerDialogue(poolStartDialogue.dialogue);
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
                    TriggerDialogue(grass1Dialogue.dialogue);
                    Grass1.transform.position = new Vector3(Grass1.transform.position.x -2, Grass1.transform.position.y, Grass1.transform.position.z);
                }
                else if (grassNum == 2)
                {
                    TriggerDialogue(grass2Dialogue.dialogue);
                    Grass2.transform.position = new Vector3(Grass2.transform.position.x -2, Grass2.transform.position.y, Grass2.transform.position.z);
                }
                else
                {
                    TriggerDialogue(grass3Dialogue.dialogue);
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
                Win();
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
                TriggerDialogue(inHouseFailDoorDialogue.dialogue);
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
                TriggerDialogue(boardStartDialogue.dialogue);
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
            TriggerDialogue(boardHintDone.dialogue);
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
                TriggerDialogue(puzzleDoneDialogue.dialogue);
                audioScriptableObject.takeItem = true;
            }
            else if (gameControllerScriptableObject.isCheckCupBoard || gameControllerScriptableObject.isCheckVase)
            {
                Debug.Log("PuzzleHalf");
                TriggerDialogue(puzzleHalfDialogue.dialogue);
            }
            else
            {
                Debug.Log("PuzzleStart");
                TriggerDialogue(puzzleStartDialogue.dialogue);
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
                TriggerDialogue(computerStartDialogue.dialogue);
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
            Win();
        }
    }

    public void LadderEvent()
    {
        if (gameControllerScriptableObject.btnEvent == "Ladder")
        {
            Debug.Log("LadderDone");
            gameControllerScriptableObject.isCheckLadder = true;
            TriggerDialogue(ladderFailDialogue.dialogue);
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

    public void Win()
    {
        if (gameControllerScriptableObject.isTakeBear && gameControllerScriptableObject.isDonePuzzle && gameControllerScriptableObject.isCheckComputer && gameControllerScriptableObject.isCheckPool && gameControllerScriptableObject.isDigTreasure && gameControllerScriptableObject.isCheckGrass)
        {
            gameControllerScriptableObject.allDone = true;
        }
        if (gameControllerScriptableObject.allDone && gameControllerScriptableObject.winCount==0)
        {
            TriggerDialogue(winDialogue.dialogue);
            gameControllerScriptableObject.winCount++;
            gameControllerScriptableObject.isPause = true;
        }
    }
}
