using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTimer : MonoBehaviour {

    [SerializeField]
    DialogueScriptable teach;
    [SerializeField]
    AudioScriptableObject audioScriptableObject;
    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    [SerializeField]
    TimerScriptableObject timerScriptableObject;
    bool once;
    int bellCount;
    int changeMusicNight;
    public GameObject ParkMorning;
    public GameObject ParkNight;
    public GameObject HouseYetMorning;
    public GameObject HouseYetNight;
    public GameObject HouseDoneMorning;
    public GameObject HouseDoneNight;
    public GameObject ghost;
    public GameObject clockArrowRoot;
    public Animator PlayerAnim;
    public AudioSource BgMusic;
    public AudioClip Morning;
    public AudioClip Night;

	// Use this for initialization
	void Start () {
        timerScriptableObject.clockTimer = 0;
        timerScriptableObject.bellTimer = 2;
        once = false;
        bellCount = 0;
        changeMusicNight = 0;
    }
	
	// Update is called once per frame
	void Update () {
        clockArrowRoot.transform.eulerAngles = new Vector3(0, 0, -timerScriptableObject.clockTimer * 3);

        if (gameControllerScriptableObject.playerDie)
        {
            timerScriptableObject.clockTimer = 89.9f;
            // gameControllerScriptableObject.playerDie = false;
        }

        if (gameControllerScriptableObject.isNight && bellCount < 3)
        {
            timerScriptableObject.bellTimer += Time.deltaTime;
            if (timerScriptableObject.bellTimer >= 2f)
            {
                bellCount++;
                audioScriptableObject.bell = true;
                timerScriptableObject.bellTimer = 0;
            }
        }
        if (gameControllerScriptableObject.PlayerRoom != "Hospital" && !gameControllerScriptableObject.isPause)
        {
            timerScriptableObject.clockTimer += Time.deltaTime;
            
            // 晚上
            if (timerScriptableObject.clockTimer >= 90 && timerScriptableObject.clockTimer < 120)
            {
                gameControllerScriptableObject.isNight = true;
                PlayerAnim.SetBool("isNight", gameControllerScriptableObject.isNight);

                // 切換背景
                ParkMorning.SetActive(false);
                ParkNight.SetActive(true);
                if (gameControllerScriptableObject.isDonePuzzle)
                {
                    HouseDoneNight.SetActive(true);
                    HouseDoneMorning.SetActive(false);
                }
                else
                {
                    HouseYetNight.SetActive(true);
                    HouseYetMorning.SetActive(false);
                }

                if (!gameControllerScriptableObject.isGhost)
                {
                    Instantiate(ghost, transform.position,transform.rotation);
                    gameControllerScriptableObject.isGhost = true;
                }               

                if (!once)
                {
                    once = true;
                    gameControllerScriptableObject.isPause = true;
                    TriggerDialogue(teach.dialogue);
                }
                if (changeMusicNight == 0)
                {
                    changeMusicNight++;
                }
                if (changeMusicNight == 1)
                {
                    changeMusicNight++;
                    Debug.Log("ChangeMusicNight");
                    BgMusic.clip = Night;
                    BgMusic.Play();
                }
            }

            // 早上
            if (timerScriptableObject.clockTimer >= 120)
            {
                changeMusicNight=0;
                BgMusic.clip = Morning;
                BgMusic.Play();
                gameControllerScriptableObject.isNight = false;
                timerScriptableObject.clockTimer = 0;
                PlayerAnim.SetBool("isNight", gameControllerScriptableObject.isNight);
                Debug.Log("isMorning");
                bellCount = 0;
                GameObject ghost1 = GameObject.FindGameObjectWithTag("Ghost");
                Destroy(ghost1);
                gameControllerScriptableObject.isGhost = false;

                // 切換背景
                ParkMorning.SetActive(true);
                ParkNight.SetActive(false);
                if (gameControllerScriptableObject.isDonePuzzle)
                {
                    HouseDoneNight.SetActive(false);
                    HouseDoneMorning.SetActive(true);
                }
                else
                {
                    HouseYetNight.SetActive(false);
                    HouseYetMorning.SetActive(true);
                }
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            timerScriptableObject.clockTimer = 89;
            gameControllerScriptableObject.isNight = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            timerScriptableObject.clockTimer = 115;
            gameControllerScriptableObject.isNight = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            timerScriptableObject.clockTimer = 119;
        }
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
