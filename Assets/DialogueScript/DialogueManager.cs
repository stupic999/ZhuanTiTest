using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour{

    public Text nameText;
    public Text dialogueText;
    public GameObject Player;
    public GameObject BoardCamere;
    public GameObject PuzzleCamere;
    public GameObject PuzzleYet;
    public GameObject PuzzleDone;
    public GameObject computerUI;
    public GameObject computerEvent;
    public GameObject normalDialogueBox;
    public GameObject boyDialogueBox;
    public GameObject fairyDialogueBox;

    public Dialogue PuzzleDone2Dialogue;

    public Animator anim;

    Queue<string> sentences;
       

	// Use this for initialization
	void Awake () {
        sentences = new Queue<string>();
	}

    public void Update()
    {
            if (GameController.talkingPerson == "Boy")
            {
                normalDialogueBox.SetActive(false);
                boyDialogueBox.SetActive(true);
                fairyDialogueBox.SetActive(false);
            }
            else if (GameController.talkingPerson == "Fairy")
            {
                normalDialogueBox.SetActive(false);
                boyDialogueBox.SetActive(false);
                fairyDialogueBox.SetActive(true);
            }
            else
            {
                normalDialogueBox.SetActive(true);
                boyDialogueBox.SetActive(false);
                fairyDialogueBox.SetActive(false);
            }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        anim.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count <= 0)
        {
            GameController.changeTalkingPerson = false;
            EndDialogue();
            return;
        }
        if (GameController.changeTalkingPerson)
        {
            if (GameController.talkingPerson == "Boy")
            {
                GameController.talkingPerson = "Fairy";
            }
            else if (GameController.talkingPerson == "Fairy")
            {
                GameController.talkingPerson = "Boy";
            }
        }
        else
        {
            GameController.talkingPerson = "";
            normalDialogueBox.SetActive(true);
            boyDialogueBox.SetActive(false);
            fairyDialogueBox.SetActive(false);
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeWord(sentence));
    }

    IEnumerator TypeWord(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    { 
        anim.SetBool("IsOpen", false);
        GameController.isPause = false;
        if (!GameController.isEventOn)
        {
            Player.SetActive(true);
            BoardCamere.SetActive(false);
            PuzzleCamere.SetActive(false);
            PuzzleDone.SetActive(false);
            PuzzleYet.SetActive(false);
            computerUI.SetActive(false);
            computerEvent.SetActive(false);
        }
        if (GameController.isPuzzleEvent)
        {
            PuzzleYet.SetActive(false);
            PuzzleDone.SetActive(true);
            GameController.isEventOn = false;
            TriggerDialogue(PuzzleDone2Dialogue);
            GameController.isPuzzleEvent = false;
        }
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}