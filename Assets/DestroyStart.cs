using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStart : MonoBehaviour {

    public GameObject gameScene;
    float timer;
    Animator StartAnim;
    public GameObject Self;

	// Use this for initialization
	void Start () {
        timer = 0;
        StartAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 30)
        {
            StartAnim.SetBool("Stop", true);
        }
        if (timer > 32.30f)
        {
            gameScene.SetActive(true);
            Destroy(Self);
        }
	}
}
