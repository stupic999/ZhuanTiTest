using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class IsPause : MonoBehaviour {

    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    public GameObject MoveUI;
    public GameObject ClockUI;
    public GameObject LightUI;
    public GameObject SettingUI;
    public AudioMixerSnapshot pausedAudio;
    public AudioMixerSnapshot unpausedAudio;

    private void Update()
    {
        if (gameControllerScriptableObject.isPause)
        {
            MoveUI.SetActive(false);
            SettingUI.SetActive(false);
            ClockUI.SetActive(false);
            pausedAudio.TransitionTo(.01f);
        }
        else
        {
            MoveUI.SetActive(true);
            SettingUI.SetActive(true);
            ClockUI.SetActive(true);            
            unpausedAudio.TransitionTo(.01f);
        }
        if (gameControllerScriptableObject.isNight && !gameControllerScriptableObject.isPause)
        {
            LightUI.SetActive(true);
        }
        else
        {
            LightUI.SetActive(false);
        }
    }
}
