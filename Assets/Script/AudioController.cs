using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    AudioScriptableObject audioScriptableObject;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioScriptableObject.takeItem = false;
        audioScriptableObject.openBag = false;
        audioScriptableObject.digSand = false;
        audioScriptableObject.openDoor = false;
        audioScriptableObject.openComputer = false;
        audioScriptableObject.btnSound = false;
        audioScriptableObject.changeMap = false;
        audioScriptableObject.error = false;
        audioScriptableObject.bell = false;
        audioScriptableObject.ghostDie = false;
        audioScriptableObject.playerDie = false;
    }

    void Update()
    {
        if (audioScriptableObject.takeItem)
        {
            audioSource.PlayOneShot(audioScriptableObject.TakeItemSound);
            audioScriptableObject.takeItem = false;
        }

        if (audioScriptableObject.openBag)
        {
            audioSource.PlayOneShot(audioScriptableObject.OpenBagSound);
            audioScriptableObject.openBag = false;
        }

        if (audioScriptableObject.digSand)
        {
            audioSource.PlayOneShot(audioScriptableObject.DigSandSound);
            audioScriptableObject.digSand = false;
        }

        if (audioScriptableObject.openDoor)
        {
            audioSource.PlayOneShot(audioScriptableObject.OpenDoorSound);
            audioScriptableObject.openDoor = false;
        }
        if (audioScriptableObject.openComputer)
        {
            audioSource.PlayOneShot(audioScriptableObject.OpenComputerSound);
            audioScriptableObject.openComputer = false;
        }
        if (audioScriptableObject.btnSound == true)
        {
            audioSource.PlayOneShot(audioScriptableObject.BtnSound);
            audioScriptableObject.btnSound = false;
        }
        if (audioScriptableObject.changeMap)
        {
            audioSource.PlayOneShot(audioScriptableObject.ChangeMapSound);
            audioScriptableObject.changeMap = false;
        }
        if (audioScriptableObject.error)
        {
            audioSource.PlayOneShot(audioScriptableObject.ErrorSound);
            audioScriptableObject.error = false;
        }
        if (audioScriptableObject.bell)
        {
            audioSource.PlayOneShot(audioScriptableObject.BellSound);
            audioScriptableObject.bell = false;
        }
        if (audioScriptableObject.ghostDie)
        {
            audioSource.PlayOneShot(audioScriptableObject.GhostDie);
            audioScriptableObject.ghostDie = false;
        }
        if (audioScriptableObject.playerDie)
        {
            audioSource.PlayOneShot(audioScriptableObject.PlayerDie);
            audioScriptableObject.playerDie = false;
        }
    }
}
