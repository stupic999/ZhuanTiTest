using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour {

    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    Image LightImage;
    public GameObject PlayerLight;
    public Animator PlayerAnim;
    public GameObject MoveUI;

    private void Awake()
    {
        LightImage = GetComponent<Image>();
        LightImage.sprite = Resources.Load<Sprite>("LightOff");
        PlayerLight.SetActive(false);
    }

    public void Update()
    {

        if (FairyMovement.isOpenLight)
        {
            LightImage.sprite = Resources.Load<Sprite>("LightOn");
            PlayerLight.SetActive(true);
            PlayerAnim.SetBool("isOpenLight", FairyMovement.isOpenLight);
            MoveUI.SetActive(false);
        }
        else
        {
            LightImage.sprite = Resources.Load<Sprite>("LightOff");
            PlayerLight.SetActive(false);
            PlayerAnim.SetBool("isOpenLight", FairyMovement.isOpenLight);
            MoveUI.SetActive(true);
        }
    }

    public void ChangeLight()
    {
        if (!gameControllerScriptableObject.isPause)
        {
            FairyMovement.isOpenLight = !FairyMovement.isOpenLight;
        }
    }
}
