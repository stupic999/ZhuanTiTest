using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShow : MonoBehaviour {

    public GameObject Self;
    float Timer;

    public void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 3.5f)
        {
            Destroy(Self);
        }
    }
}
