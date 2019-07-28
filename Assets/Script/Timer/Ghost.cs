using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    [SerializeField]
    TimerScriptableObject timerScriptableObject;
    [SerializeField]
    AudioScriptableObject audioScriptableObject;
    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    FairyDead fairyDead;
    string GhostFace;
    int ghostCount;
    SpriteRenderer ghostSprite;
    AudioSource ghostAudio;
    Animator GhostAnim;
    public Transform playerTransform;
    public GameObject Player;
    public GameObject ghostRoot;

    private void Start()
    {
        timerScriptableObject.ghostTimer = 0;
        gameControllerScriptableObject.ghostDie = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        fairyDead = Player.GetComponent<FairyDead>();
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
        if (gameControllerScriptableObject.ghostDie)
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
        if (!gameControllerScriptableObject.isPause && !gameControllerScriptableObject.ghostDie && !gameControllerScriptableObject.isEventOn)
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
        if (!gameControllerScriptableObject.isPause && !gameControllerScriptableObject.isEventOn)
        {
            if (gameControllerScriptableObject.ghostDie)
            {
                timerScriptableObject.ghostTimer += Time.deltaTime;
                if (timerScriptableObject.ghostTimer >= 4.9f)
                {
                    Destroy(ghostRoot);
                    gameControllerScriptableObject.isGhost = false;
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!gameControllerScriptableObject.ghostDie)
        {
            if (other.tag == "Light")
            {
                audioScriptableObject.ghostDie = true;
                timerScriptableObject.ghostTimer = 0;
                GhostAnim.enabled = true;
                gameControllerScriptableObject.ghostDie = true;
                Debug.Log("Die");
                ghostAudio.volume = 0;
            }
            else if (other.tag == "Player")
            {
                FairyDead();
            }
        }
    }

        public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void FairyDead()
    {
        fairyDead.FairyRIP();
        Destroy(ghostRoot);
    }
}
