using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBtn : MonoBehaviour {

    public GameObject CloseItem;

    public void isCloseBtn()
    {
        CloseItem.SetActive(false);
    }
}
