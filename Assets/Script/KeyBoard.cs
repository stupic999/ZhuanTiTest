﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoard : MonoBehaviour
{
    [SerializeField]
    DialogueScriptable passwordDoneDialogue;
    [SerializeField]
    DialogueScriptable passwordFailDialogue;
    [SerializeField]
    AudioScriptableObject audioScriptableObject;
    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;

    int Count;
    List<string> Password = new List<string>();
    public Text PasswordText;
    public GameObject mainCamare;

    public void Update()
    {
        if (Count == 4)
        {
            if (PasswordText.text == "0522")
            {
                gameControllerScriptableObject.isPause = true;
                Count = 0;
                gameControllerScriptableObject.isCheckComputer = true;                
                Password.Clear();
                gameControllerScriptableObject.btnEvent = "ComputerEvent";
                gameControllerScriptableObject.isBtnClick = true;
                Debug.Log("ComputerDonePassword");
                gameControllerScriptableObject.isEventOn = false;
                TriggerDialogue(passwordDoneDialogue.dialogue);
            }
            else
            {
                Debug.Log("ComputerPasswordWrong");
                audioScriptableObject.error = true;
                gameControllerScriptableObject.isPause = true;
                Count = 0;
                DialogueManager.passwordError = true;
                TriggerDialogue(passwordFailDialogue.dialogue);
                Password.Clear();
            }
        }
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void Click9()
    {
        if (!gameControllerScriptableObject.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "9";
            Password.Add("9");
            audioScriptableObject.btnSound = true;
        }
    }
    public void Click8()
    {
        if (!gameControllerScriptableObject.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "8";
            Password.Add("8");
            audioScriptableObject.btnSound = true;
        }
    }
    public void Click7()
    {
        if (!gameControllerScriptableObject.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "7";
            Password.Add("7");
            audioScriptableObject.btnSound = true;
        }
    }
    public void Click6()
    {
        if (!gameControllerScriptableObject.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "6";
            Password.Add("6");
            audioScriptableObject.btnSound = true;
        }
    }
    public void Click5()
    {
        if (!gameControllerScriptableObject.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "5";
            Password.Add("5");
            audioScriptableObject.btnSound = true;
        }
    }
    public void Click4()
    {
        if (!gameControllerScriptableObject.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "4";
            Password.Add("4");
            audioScriptableObject.btnSound = true;
        }
    }
    public void Click3()
    {
        if (!gameControllerScriptableObject.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "3";
            Password.Add("3");
            audioScriptableObject.btnSound = true;
        }
    }
    public void Click2()
    {
        if (!gameControllerScriptableObject.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "2";
            Password.Add("2");
            audioScriptableObject.btnSound = true;
        }
    }
    public void Click1()
    {
        if (!gameControllerScriptableObject.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "1";
            Password.Add("1");
            audioScriptableObject.btnSound = true;
        }
    }
    public void Click0()
    {
        if (!gameControllerScriptableObject.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "0";
            Password.Add("0");
            audioScriptableObject.btnSound = true;
        }
    }
    public void ClickDel()
    {
        if (!gameControllerScriptableObject.isPause)
        {
            audioScriptableObject.btnSound = true;
            if (Count > 0)
            {
                Count--;
                Password.RemoveAt(Count);
                PasswordText.text = "";
                for (int i = 0; i < Password.Count; i++)
                {
                    PasswordText.text = PasswordText.text + Password[i];
                }
            }
        }
    }
    public void CloseComputer()
    {
        if (!gameControllerScriptableObject.isPause)
        {
            Count = 0;
            Password.Clear();
            PasswordText.text = "";
            audioScriptableObject.btnSound = true;
            gameControllerScriptableObject.isPause = false;
            gameControllerScriptableObject.isEventOn = false;
            mainCamare.SetActive(true);
        }
    }
}
