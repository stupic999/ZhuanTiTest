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
    float timer;
    bool once;
    int bellCount;
    float bellTimer = 2f;
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
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        clockArrowRoot.transform.eulerAngles = new Vector3(0, 0, -timer * 3);

        if (gameControllerScriptableObject.playerDie)
        {
            timer = 89.9f;
            gameControllerScriptableObject.playerDie = false;
        }

        if (gameControllerScriptableObject.isNight && bellCount < 3)
        {
            bellTimer += Time.deltaTime;
            if (bellTimer >= 2f)
            {
                bellCount++;
                audioScriptableObject.bell = true;
                bellTimer = 0;
            }
        }
        if (gameControllerScriptableObject.PlayerRoom != "Hospital" && !gameControllerScriptableObject.isPause)
        {
            timer += Time.deltaTime;
            
            // 晚上
            if (timer >= 90 && timer < 120)
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
            if (timer >= 120)
            {
                changeMusicNight=0;
                BgMusic.clip = Morning;
                BgMusic.Play();
                gameControllerScriptableObject.isNight = false;
                timer = 0;
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
            timer = 89;
            gameControllerScriptableObject.isNight = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            timer = 115;
            gameControllerScriptableObject.isNight = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            timer = 119;
        }
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
