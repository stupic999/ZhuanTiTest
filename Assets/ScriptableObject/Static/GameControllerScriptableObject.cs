using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameControllerScriptableObject : ScriptableObject
{
    public int winCount;
    public int MapCount;
    public bool MapOpen;
    public bool isPause;
    public bool isEventOn;
    public bool isPuzzleEvent;
    public bool allDone;
    public bool playerDie;
    public bool isBtnClick;
    public bool isTalkWithBoy;
    public bool isSeeBread;
    public bool isSeePaper;
    public bool isTakeFishBait;
    public bool isCheckPool;
    public bool isDigTreasure;
    public bool isCheckGrass;
    public bool isCheckVase;
    public bool isCheckCupBoard;
    public bool isDonePuzzle;
    public bool isCheckShoes;
    public bool isOpenDoor;
    public bool isCheckBoard;
    public bool isCheckComputer;
    public bool isTakeBear;
    public bool isBoardHint;
    public bool isCheckLadder;
    public bool isNight;
    public bool isGhost;
    public bool ghostDie;
    public bool isOpenLight;
    public string btnEvent;
    public string EventName;
    public string PlayerRoom = "Hospital";
    public string PortalPlace;
    public string PlayerFace = "L";
}
