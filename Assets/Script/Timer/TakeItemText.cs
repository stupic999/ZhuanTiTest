using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItemText : MonoBehaviour {

    [SerializeField]
    TimerScriptableObject timerScriptableObject;
    Text takeItemText;

    void Awake()
    {
        takeItemText = GetComponent<Text>();
        takeItemText.text = "";
        timerScriptableObject.takeItemTimer = 0;
    }

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
