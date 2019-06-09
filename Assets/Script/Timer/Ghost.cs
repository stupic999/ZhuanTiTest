using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    [SerializeField]
    TimerScriptableObject timerScriptableObject;
    [SerializeField]
    AudioScriptableObject audioScriptableObject;
    string GhostFace;
    int ghostCount;
    SpriteRenderer ghostSprite;
    AudioSource ghostAudio;
    Animator GhostAnim;

    [SerializeField]
    DialogueScriptable playerDie;

    public GameObject ghostRoot;
    public static bool ghostDie;
    public Transform playerTransform;
    public GameObject Player;
    public GameObject MainCamera;

    private void Start()
    {
        ghostDie = false;
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        Player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = Player.transform;
        GhostAnim =GetComponent<Animator>();
        GhostAnim.enabled = false;
        ghostSprite=GetComponent<SpriteRenderer>();
        ghostSprite.color = new Color(255, 255, 255, 0); 
        ghostAudio = GetComponent<AudioSource>();
        ghostAudio.volume = 0f;
        ghostCount = Random.Range(1, 3);
        if (ghostCount == 1)
        {
            GhostFace = "R";
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.position = new Vector3(playerTransform.position.x - 60, playerTransform.position.y, playerTransform.position.z);
        }
        else if (ghostCount == 2)
        {
            GhostFace = "L";
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position = new Vector3(playerTransform.position.x + 60, playerTransform.position.y, playerTransform.position.z);
        }
        if (ghostDie)
        {
            timerScriptableObject.ghostTimer += Time.deltaTime;
            if (timerScriptableObject.ghostTimer >= 5)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        if (!GameController.isPause && !ghostDie && !GameController.isEventOn)
        {
            timerScriptableObject.ghostTimer += Time.deltaTime;
            if (timerScriptableObject.ghostTimer >= 0.12)
            {
                timerScriptableObject.ghostTimer = 0;
                if (GhostFace == "R")
                {
                    transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                    ghostAudio.volume += 0.025f;
                    ghostSprite.color = new Color(255, 255, 255, ghostSprite.color.a + 0.0075f);
                }
                else if (GhostFace == "L")
                {
                    transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
                    ghostAudio.volume += 0.025f;
                    ghostSprite.color = new Color(255, 255, 255, ghostSprite.color.a + 0.0075f);
                }
            }
        }
        if (!GameController.isPause && !GameController.isEventOn)
        {
            if (ghostDie)
            {
                timerScriptableObject.ghostTimer += Time.deltaTime;
                if (timerScriptableObject.ghostTimer >= 4.9f)
                {
                    Destroy(ghostRoot);
                    ClockTimer.isGhost = false;
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!ghostDie)
        {
            if (other.tag == "Light")
            {
                audioScriptableObject.ghostDie = true;
                timerScriptableObject.ghostTimer = 0;
                GhostAnim.enabled = true;
                ghostDie = true;
                Debug.Log("Die");
                ghostAudio.volume = 0;
            }
            else if (other.tag == "Player")
            {
                audioScriptableObject.playerDie = true;
                GameController.playerDie = true;
                Destroy(ghostRoot);
                GameController.PlayerRoom = "Hospital";
                Player.transform.position = new Vector3(-231.81f, 1.29f, 0);
                Player.transform.eulerAngles = new Vector3(0, 0, 0);
                MainCamera.transform.position = new Vector3(-231.5f, 0, MainCamera.transform.position.z);
                ClockTimer.isGhost = false;
                TriggerDialogue(playerDie.dialogue);
                ClockTimer.isNight = false;
            }
        }
    }

        public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
