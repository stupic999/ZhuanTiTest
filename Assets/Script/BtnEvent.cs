using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnEvent : MonoBehaviour {

    public void isBtnEvent()
    {
        if(!FairyMovement.isOpenLight)
        GameController.isBtnClick = true;
    }
}
