using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static bool isOpenNewsPaper;

    public static bool isGameOver;
    public GameObject GameOverText;
    public static bool isWin;
    public GameObject WinText;
    public static bool isLoadingScene;
    public static string LoadingSceneName;

    // Use this for initialization
    void Start () {
        GameOverText.SetActive(false);
        WinText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (isGameOver)
        {
            GameOverText.SetActive(true);
        }
        if (isWin)
        {
            WinText.SetActive(true);
        }
	}
}
