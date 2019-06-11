using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AudioScriptableObject : ScriptableObject
{
    public bool takeItem;
    public bool openBag;
    public bool digSand;
    public bool openDoor;
    public bool openComputer;
    public bool btnSound;
    public bool changeMap;
    public bool error;
    public bool bell;
    public bool ghostDie;
    public bool playerDie;
    public AudioClip TakeItemSound;
    public AudioClip OpenBagSound;
    public AudioClip DigSandSound;
    public AudioClip OpenDoorSound;
    public AudioClip OpenComputerSound;
    public AudioClip BtnSound;
    public AudioClip ChangeMapSound;
    public AudioClip ErrorSound;
    public AudioClip BellSound;
    public AudioClip GhostDie;
    public AudioClip PlayerDie;
}
