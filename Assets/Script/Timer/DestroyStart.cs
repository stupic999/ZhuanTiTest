using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStart : MonoBehaviour {

    [SerializeField]
    TimerScriptableObject timerScriptableObject;
    Animator StartAnim;
    public GameObject gameScene;
    public GameObject Self;
    public GameObject Skip;

    // Use this for initialization
    void Start () {
        StartAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        timerScriptableObject.startTimer += Time.deltaTime;
        if (timerScriptableObject.startTimer > 30)
        {
            StartAnim.SetBool("Stop", true);
        }
        if (timerScriptableObject.startTimer > 32.30f)
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
