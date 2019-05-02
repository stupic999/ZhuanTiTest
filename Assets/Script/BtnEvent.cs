using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnEvent : MonoBehaviour {

    public void OpenNewsPaper()
    {
        GameController.isOpenNewsPaper = true;
    }
}
