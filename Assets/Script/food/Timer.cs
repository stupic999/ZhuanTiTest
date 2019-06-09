using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    float OneDay;
    float SkyTimer;
    float skyRotate;
    public GameObject Sky;

	// Use this for initialization
	void Start () {
        OneDay = 0;
        SkyTimer = 0;        
    }

    // Update is called once per frame
    void Update() {
        if (GameControllerFood.isWin != true)
        {
            SkyTimerCount();
            Sky.transform.eulerAngles = new Vector3(0, 0, skyRotate);
            skyRotate = Mathf.Round(OneDay) * 4;
        }
        if (OneDay < 90)
        {
            Debug.Log(OneDay);
            OneDay += Time.deltaTime;            
        }
        else
        {
            GameControllerFood.isWin = true;
            Sky.transform.eulerAngles = new Vector3(0, 0, 0);
        }
	}

    public void SkyTimerCount()
    {
        if (SkyTimer < 1)
        {
            SkyTimer += Time.deltaTime;
        }
        else
        {
            SkyTimer = 0;
            Sky.transform.Rotate(0, 0, 4);
        }
    }
}
