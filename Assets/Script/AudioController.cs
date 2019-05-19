using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    AudioSource audioSource;
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

    public static bool takeItem;
    public static bool openBag;
    public static bool digSand;
    public static bool openDoor;
    public static bool openComputer;
    public static bool btnSound;
    public static bool changeMap;
    public static bool error;
    public static bool bell;
    public static bool ghostDie;
    public static bool playerDie;



    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (takeItem)
        {
            audioSource.PlayOneShot(TakeItemSound);
            takeItem = false;
        }

        if (openBag)
        {
            audioSource.PlayOneShot(OpenBagSound);
            openBag = false;
        }

        if (digSand)
        {
            audioSource.PlayOneShot(DigSandSound);
            digSand = false;
        }

        if (openDoor)
        {
            audioSource.PlayOneShot(OpenDoorSound);
            openDoor = false;
        }
        if (openComputer)
        {
            audioSource.PlayOneShot(OpenComputerSound);
            openComputer = false;
        }
        if (btnSound == true)
        {
            audioSource.PlayOneShot(BtnSound);
            btnSound = false;
        }
        if (changeMap)
        {
            audioSource.PlayOneShot(ChangeMapSound);
            changeMap = false;
        }
        if (error)
        {
            audioSource.PlayOneShot(ErrorSound);
            error= false;
        }
        if (bell)
        {
            audioSource.PlayOneShot(BellSound);
            bell = false;
        }
        if (ghostDie)
        {
            audioSource.PlayOneShot(GhostDie);
            ghostDie = false;
        }
        if (playerDie)
        {
            audioSource.PlayOneShot(PlayerDie);
            playerDie = false;
        }
    }
}
