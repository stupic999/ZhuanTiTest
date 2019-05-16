using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoard : MonoBehaviour
{

    public Text PasswordText;
    List<string> Password=new List<string>();

    int Count;

    public Dialogue PasswordDoneDialogue;
    public Dialogue PasswordFailDialogue;

    public void Update()
    {
        if (Count == 4)
        {
            if (PasswordText.text == "5022")
            {
                GameController.isPause = true;
                Count = 0;
                GameController.isCheckComputer = true;                
                Password.Clear();
                GameController.btnEvent = "ComputerEvent";
                GameController.isBtnClick = true;
                Debug.Log("ComputerDonePassword");
                GameController.isEventOn = false;
                TriggerDialogue(PasswordDoneDialogue);
            }
            else
            {
                GameController.isPause = true;
                Count = 0;
                PasswordText.text = "";
                TriggerDialogue(PasswordFailDialogue);
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
        }
    }
    public void Click8()
    {
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "8";
            Password.Add("8");
        }
    }
    public void Click7()
    {
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "7";
            Password.Add("7");
        }
    }
    public void Click6()
    {
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "6";
            Password.Add("6");
        }
    }
    public void Click5()
    {
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "5";
            Password.Add("5");
        }
    }
    public void Click4()
    {
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "4";
            Password.Add("4");
        }
    }
    public void Click3()
    {
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "3";
            Password.Add("3");
        }
    }
    public void Click2()
    {
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "2";
            Password.Add("2");
        }
    }
    public void Click1()
    {
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "1";
            Password.Add("1");
        }
    }
    public void Click0()
    {
        if (!GameController.isPause)
        {
            Count++;
            PasswordText.text = PasswordText.text + "0";
            Password.Add("0");
        }
    }
    public void ClickDel()
    {
        if (!GameController.isPause)
        {
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
}
