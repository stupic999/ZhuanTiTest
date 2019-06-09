using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour{

    [SerializeField]
    DialogueScriptable firstDoneDialogue;
    [SerializeField]
    DialogueScriptable puzzleDone2Dialogue;

    Queue<string> sentences;
    public Text passwordText;
    public Text dialogueText;
    public Animator anim;
    public GameObject mainCamera;
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
    public GameObject SmallScene;
    public GameObject EndAnimation;
    public int sentenceCount;
    public string talkingPerson;
    public static bool passwordError;

    void Awake () {
        sentences = new Queue<string>();
	}

    void Update()
    {
        if (anim.GetBool("IsOpen") == true)
        {
            GameController.isPause = true;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        anim.SetBool("IsOpen", true);

        talkingPerson = dialogue.name;

        if (dialogue.name != "")
        {
            if (dialogue.name == "Fairy")
            {
                normalDialogueBox.SetActive(false);
                boyDialogueBox.SetActive(false);
                fairyDialogueBox.SetActive(true);
            }
            if (dialogue.name == "Boy")
            {
                normalDialogueBox.SetActive(false);
                boyDialogueBox.SetActive(true);
                fairyDialogueBox.SetActive(false);
            }
        }
        else
        {
            normalDialogueBox.SetActive(true);
            boyDialogueBox.SetActive(false);
            fairyDialogueBox.SetActive(false);
        }
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        sentenceCount = sentences.Count;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (GameController.EventName == "PuzzleEvent")
        {
            GameController.isEventOn = false;
        }

        AudioController.btnSound = true;
        if (sentences.Count <= 0)
        {
            EndDialogue();
            return;
        }

        if (talkingPerson == "BothFairyNow")
        {
            if (sentences.Count % 2 == 0 && sentenceCount % 2 == 0)
            {
                Debug.Log("BF1");
                normalDialogueBox.SetActive(false);
                boyDialogueBox.SetActive(false);
                fairyDialogueBox.SetActive(true);
            }
            else
            {
                Debug.Log("BF2");
                normalDialogueBox.SetActive(false);
                boyDialogueBox.SetActive(true);
                fairyDialogueBox.SetActive(false);
            }
        }
        else if (talkingPerson == "BothBoyNow")
        {
            if (sentenceCount % 2 == 0)
            {
                if (sentences.Count % 2 == 0)
                {
                    normalDialogueBox.SetActive(false);
                    boyDialogueBox.SetActive(true);
                    fairyDialogueBox.SetActive(false);
                }
                else
                {
                    normalDialogueBox.SetActive(false);
                    boyDialogueBox.SetActive(false);
                    fairyDialogueBox.SetActive(true);
                }
            }
            if (sentenceCount % 2 != 0)
            {
                if (sentences.Count % 2 == 0)
                {
                    normalDialogueBox.SetActive(false);
                    boyDialogueBox.SetActive(false);
                    fairyDialogueBox.SetActive(true);
                }
                else
                {
                    normalDialogueBox.SetActive(false);
                    boyDialogueBox.SetActive(true);
                    fairyDialogueBox.SetActive(false);
                }
            }
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
            mainCamera.SetActive(true);
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
            GameController.isPause = true;
            TriggerDialogue(puzzleDone2Dialogue.dialogue);
            GameController.isPuzzleEvent = false;
            GameController.isDonePuzzle  = true;
        }
        if (GameController.winCount == 1)
        {
            GameController.winCount++;
            EndAnimation.SetActive(true);
            SmallScene.SetActive(false);
        }
        if (GameController.allDone && GameController.winCount==0)
        {
            TriggerDialogue(firstDoneDialogue.dialogue);
            GameController.isPause = true;
            GameController.winCount++;
        }
        if (passwordError)
        {
            passwordError = false;
            passwordText.text = "";
        }
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}