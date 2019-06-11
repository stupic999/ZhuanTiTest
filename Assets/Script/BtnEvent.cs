using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnEvent : MonoBehaviour {

    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;

    public void isBtnEvent()
    {
        if(!gameControllerScriptableObject.isOpenLight)
            gameControllerScriptableObject.isBtnClick = true;
    }
}
