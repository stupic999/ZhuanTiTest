using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItemText : MonoBehaviour {

    [SerializeField]
    TimerScriptableObject timerScriptableObject;
    Text takeItemText;

	// Use this for initialization
	void Start () {
        takeItemText = GetComponent<Text>();
        takeItemText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        if (takeItemText.text != "")
        {
            timerScriptableObject.takeItemTimer += Time.deltaTime;
            if (timerScriptableObject.takeItemTimer > 1.5)
            {
                timerScriptableObject.takeItemTimer = 0;
                takeItemText.text = "";
            }
        }
	}
}
