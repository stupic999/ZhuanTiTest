using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class FairyDead : MonoBehaviour {

    [SerializeField]
    CamreShakeTest camreShakeTest;
    [SerializeField]
    AudioScriptableObject audioScriptableObject;
    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    public SpriteRenderer deadBg;
    float deadBgColorA;
    

    // Use this for initialization
    void Awake () {
        deadBgColorA = 0;
        deadBg.color = new Color(255, 255, 255, deadBgColorA);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FairyRIP();
        }
        
        if (gameControllerScriptableObject.playerDie != false)
        {
            deadBgColorA += 0.0005f;
        }
        else
        {
            deadBgColorA = 0;
        }

        if (gameControllerScriptableObject.playerDie != false && deadBg.color.a < 1) 
        {
            deadBg.color += new Color(255, 255, 255, deadBgColorA);
        }
	}

    public void FairyRIP()
    {
        camreShakeTest.FairyRipShake();
        audioScriptableObject.playerDie = true;
        gameControllerScriptableObject.playerDie = true;
        gameControllerScriptableObject.isPause = true;
    }
}
