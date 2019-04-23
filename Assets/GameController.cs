using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static bool isGameOver;
    public GameObject GameOverText;

	// Use this for initialization
	void Start () {
        GameOverText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (isGameOver)
        {
            GameOverText.SetActive(true);
        }
	}
}
