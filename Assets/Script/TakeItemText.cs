using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItemText : MonoBehaviour {

    Text takeItemText;
    float timer;

	// Use this for initialization
	void Start () {
        takeItemText = GetComponent<Text>();
        takeItemText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        if (takeItemText.text != "")
        {
            timer += Time.deltaTime;
            if (timer > 1.5)
            {
                timer = 0;
                takeItemText.text = "";
            }
        }
	}
}
