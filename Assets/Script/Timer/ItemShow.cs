using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShow : MonoBehaviour {

    [SerializeField]
    TimerScriptableObject timerScriptableObject;
    public GameObject Self;

    public void Update()
    {
        timerScriptableObject.itemShowTimer += Time.deltaTime;
        if (timerScriptableObject.itemShowTimer >= 3.5f)
        {
            Destroy(Self);
        }
    }
}
