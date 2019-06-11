using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShow : MonoBehaviour {

    [SerializeField]
    TimerScriptableObject timerScriptableObject;
    public GameObject Self;

    private void Awake()
    {
        timerScriptableObject.itemShowTimer = 0;
    }

    public void Update()
    {
        timerScriptableObject.itemShowTimer += Time.deltaTime;
        if (timerScriptableObject.itemShowTimer >= 3.5f)
        {
            timerScriptableObject.itemShowTimer = 0;
            Destroy(Self);
        }
    }
}
