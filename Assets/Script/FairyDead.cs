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
    public Animator fairyDeadAnim;
    //float timer;

    void Update () {
        //if (gameControllerScriptableObject.playerDie != false)
        //{
        //    timer+= Time.deltaTime;
        //    if (timer <= 4.5)
        //    {
        //        timer = 0;
        //        fairyDeadAnim.SetBool("FairyDead", false);             
        //    }
        //}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FairyRIP();
        }
	}

    public void FairyRIP()
    {
        fairyDeadAnim.SetBool("FairyDead", true);
        camreShakeTest.FairyRipShake();
        audioScriptableObject.playerDie = true;
        gameControllerScriptableObject.playerDie = true;
        gameControllerScriptableObject.isPause = true;
    }
}
