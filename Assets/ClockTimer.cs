using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTimer : MonoBehaviour {

    public GameObject clockArrowRoot;
    float timer;
    public static bool isNight;

	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameController.PlayerRoom != "Hospital" && !GameController.isPause)
        {
            timer += Time.deltaTime;
            clockArrowRoot.transform.eulerAngles = new Vector3(0, 0, -timer * 3);
            if (timer >= 90 && timer < 120)
            {
                isNight = true;
                Debug.Log(isNight);
            }
            else if (timer >= 120)
            {
                isNight = false;
                timer = 0;
                Debug.Log(isNight);
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            timer = 90;
            isNight = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            timer = 0;
            isNight = false;
        }
    }
}
