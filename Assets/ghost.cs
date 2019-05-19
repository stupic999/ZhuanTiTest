using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour {

    string GhostFace;
    int ghostCount;
    public GameObject ghostRoot;
    float timer;
    public static bool ghostDie;
    AudioSource ghostAudio;
    SpriteRenderer ghostSprite;
    public Transform playerTransform;
    Animator GhostAnim;
    public GameObject Player;
    public GameObject MainCamera;
    public Dialogue playerDie;

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
       ghostCount= Random.Range(1, 3);
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
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        if (!GameController.isPause && !ghostDie)
        {
            timer += Time.deltaTime;
            if (timer >= 0.12)
            {
                timer = 0;
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
        if (ghostDie)
        {
            timer += Time.deltaTime;
            if (timer >= 4.9f)
            {
                Destroy(ghostRoot);
                ClockTimer.isGhost = false;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!ghostDie)
        {
            if (other.tag == "Light")
            {
                AudioController.ghostDie = true;
                timer = 0;
                GhostAnim.enabled = true;
                ghostDie = true;
                Debug.Log("Die");
                ghostAudio.volume = 0;
            }
            else if (other.tag == "Player")
            {
                AudioController.playerDie = true;
                GameController.playerDie = true;
                Destroy(ghostRoot);
                GameController.PlayerRoom = "Hospital";
                Player.transform.position = new Vector3(-231.81f, 1.29f, 0);
                Player.transform.eulerAngles = new Vector3(0, 0, 0);
                MainCamera.transform.position = new Vector3(-231.5f, 0, MainCamera.transform.position.z);
                ClockTimer.isGhost = false;
                TriggerDialogue(playerDie);
                ClockTimer.isNight = false;
            }
        }
    }

        public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
