using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStart : MonoBehaviour {

    public GameObject gameScene;
    float timer;
    Animator StartAnim;
    public GameObject Self;
    public GameObject Skip;

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
            Begin();
        }
	}

    public void ShowSkip()
    {
        Skip.SetActive(true);
    }

    public void Begin()
    {
        gameScene.SetActive(true);
        Destroy(Self);
    }
}
