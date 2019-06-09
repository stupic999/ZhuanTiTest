using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoard : MonoBehaviour
{
    [SerializeField]
    DialogueScriptable passwordDoneDialogue;
    [SerializeField]
    DialogueScriptable passwordFailDialogue;

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
                GameController.isPause = true;
                Count = 0;
                GameController.isCheckComputer = true;                
                Password.Clear();
                GameController.btnEvent = "ComputerEvent";
                GameController.isBtnClick = true;
                Debug.Log("ComputerDonePassword");
                GameController.isEventOn = false;
                TriggerDialogue(passwordDoneDialogue.dialogue);
            }
            else
            {
                Debug.Log("ComputerPasswordWrong");
                AudioController.error = true;
                GameController.isPause = true;
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
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "9";
            Password.Add("9");
            AudioController.btnSound = true;
        }
    }
    public void Click8()
    {
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "8";
            Password.Add("8");
            AudioController.btnSound = true;
        }
    }
    public void Click7()
    {
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "7";
            Password.Add("7");
            AudioController.btnSound = true;
        }
    }
    public void Click6()
    {
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "6";
            Password.Add("6");
            AudioController.btnSound = true;
        }
    }
    public void Click5()
    {
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "5";
            Password.Add("5");
            AudioController.btnSound = true;
        }
    }
    public void Click4()
    {
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "4";
            Password.Add("4");
            AudioController.btnSound = true;
        }
    }
    public void Click3()
    {
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "3";
            Password.Add("3");
            AudioController.btnSound = true;
        }
    }
    public void Click2()
    {
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "2";
            Password.Add("2");
            AudioController.btnSound = true;
        }
    }
    public void Click1()
    {
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "1";
            Password.Add("1");
            AudioController.btnSound = true;
        }
    }
    public void Click0()
    {
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "0";
            Password.Add("0");
            AudioController.btnSound = true;
        }
    }
    public void ClickDel()
    {
        if (!GameController.isPause)
        {
            AudioController.btnSound = true;
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
        if (!GameController.isPause)
        {
            Count = 0;
            Password.Clear();
            PasswordText.text = "";
            AudioController.btnSound = true;
            GameController.isPause = false;
            GameController.isEventOn = false;
            mainCamare.SetActive(true);
        }
    }
}
