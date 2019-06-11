using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour{

    [SerializeField]
    DialogueScriptable firstDoneDialogue;
    [SerializeField]
    DialogueScriptable puzzleDone2Dialogue;
    [SerializeField]
    AudioScriptableObject audioScriptableObject;
    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
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
        passwordText.text = "";
        dialogueText.text = "";
        mainCamera.SetActive(true);
        Player.SetActive(true);
        BoardCamere.SetActive(false);
        PuzzleCamere.SetActive(false);
        PuzzleYet.SetActive(true);
        PuzzleDone.SetActive(false);
        computerUI.SetActive(false);
        computerEvent.SetActive(false);
        SmallScene.SetActive(false);
        EndAnimation.SetActive(false);
        sentenceCount = 0;
        talkingPerson = "";
        passwordError = false;
    }

    void Update()
    {
        if (anim.GetBool("IsOpen") == true)
        {
            gameControllerScriptableObject.isPause = true;
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
        if (gameControllerScriptableObject.EventName == "PuzzleEvent")
        {
            gameControllerScriptableObject.isEventOn = false;
        }

        audioScriptableObject.btnSound = true;
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
        gameControllerScriptableObject.isPause = false;
        if (!gameControllerScriptableObject.isEventOn)
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
        if (gameControllerScriptableObject.isPuzzleEvent)
        {
            PuzzleYet.SetActive(false);
            PuzzleDone.SetActive(true);
            gameControllerScriptableObject.isEventOn = false;
            gameControllerScriptableObject.isPause = true;
            TriggerDialogue(puzzleDone2Dialogue.dialogue);
            gameControllerScriptableObject.isPuzzleEvent = false;
            gameControllerScriptableObject.isDonePuzzle  = true;
        }
        if (gameControllerScriptableObject.winCount == 1)
        {
            gameControllerScriptableObject.winCount++;
            EndAnimation.SetActive(true);
            SmallScene.SetActive(false);
        }
        if (gameControllerScriptableObject.allDone && gameControllerScriptableObject.winCount==0)
        {
            TriggerDialogue(firstDoneDialogue.dialogue);
            gameControllerScriptableObject.isPause = true;
            gameControllerScriptableObject.winCount++;
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