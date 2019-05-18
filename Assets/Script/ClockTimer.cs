using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTimer : MonoBehaviour {

    public GameObject ParkMorning;
    public GameObject ParkNight;
    public GameObject HouseYetMorning;
    public GameObject HouseYetNight;
    public GameObject HouseDoneMorning;
    public GameObject HouseDoneNight;

    public GameObject clockArrowRoot;
    public AudioSource BgMusic;
    public AudioClip Morning;
    public AudioClip Night;
    float timer;
    public static bool isNight;
    public Animator PlayerAnim;
    bool once;
    public Dialogue teach;
    int bellCount;
    float bellTimer=2f;
    int changeMusicNight;

	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (isNight && bellCount < 3)
        {
            bellTimer += Time.deltaTime;
            if (bellTimer >= 2f)
            {
                bellCount++;
                AudioController.bell = true;
                bellTimer = 0;
            }
        }
        if (GameController.PlayerRoom != "Hospital" && !GameController.isPause)
        {
            timer += Time.deltaTime;
            clockArrowRoot.transform.eulerAngles = new Vector3(0, 0, -timer * 3);
            
            // 晚上
            if (timer >= 90 && timer < 120)
            {
                isNight = true;
                PlayerAnim.SetBool("isNight", isNight);

                // 切換背景
                ParkMorning.SetActive(false);
                ParkNight.SetActive(true);
                if (GameController.isDonePuzzle)
                {
                    HouseDoneNight.SetActive(true);
                    HouseDoneMorning.SetActive(false);
                }
                else
                {
                    HouseYetNight.SetActive(true);
                    HouseYetMorning.SetActive(false);
                }

                if (!once)
                {
                    once = true;
                    TriggerDialogue(teach);
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
                isNight = false;
                timer = 0;
                PlayerAnim.SetBool("isNight", isNight);
                Debug.Log("isMorning");
                bellCount = 0;

                // 切換背景
                ParkMorning.SetActive(true);
                ParkNight.SetActive(false);
                if (GameController.isDonePuzzle)
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
            isNight = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            timer = 115;
            isNight = true;
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
