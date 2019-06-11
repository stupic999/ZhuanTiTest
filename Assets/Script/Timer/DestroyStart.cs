using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStart : MonoBehaviour {

    [SerializeField]
    TimerScriptableObject timerScriptableObject;
    Animator StartAnim;
    public GameObject gameSmallScene;
    public GameObject Self;
    public GameObject Skip;

    private void Awake()
    {
        timerScriptableObject.startTimer = 0f;
        gameSmallScene.SetActive(true);
    }

    // Use this for initialization
    void Start () {
        StartAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        timerScriptableObject.startTimer += Time.deltaTime;
        if (timerScriptableObject.startTimer >= 32.30f)
        {
            Begin();
        }
        else if (timerScriptableObject.startTimer > 30)
        {
            StartAnim.SetBool("Stop", true);
        }
	}

    public void ShowSkip()
    {
        Skip.SetActive(true);
    }

    public void Begin()
    {
        gameSmallScene.SetActive(true);
        Destroy(Self);
    }
}
