using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShow : MonoBehaviour {

    public GameObject ContinueBtn;
    public GameObject Self;
    float Timer;

    public void Start()
    {
        ContinueBtn.SetActive(false);
    }

    public void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 3.5f)
        {
            ContinueBtn.SetActive(true);
            Destroy(Self);
        }
    }
}
