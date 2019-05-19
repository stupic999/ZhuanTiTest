using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour {

    Image LightImage;
    public GameObject PlayerLight;
    public Animator PlayerAnim;

    private void Awake()
    {
        LightImage = GetComponent<Image>();
        LightImage.sprite = Resources.Load<Sprite>("LightOff");
        PlayerLight.SetActive(false);
    }

    public void ChangeLight()
    {
        if (!GameController.isPause)
        {
            FairyMovement.isOpenLight = !FairyMovement.isOpenLight;
            if (FairyMovement.isOpenLight)
            {
                LightImage.sprite = Resources.Load<Sprite>("LightOn");
                PlayerLight.SetActive(true);
                PlayerAnim.SetBool("isOpenLight", FairyMovement.isOpenLight);
            }
            else
            {
                LightImage.sprite = Resources.Load<Sprite>("LightOff");
                PlayerLight.SetActive(false);
                PlayerAnim.SetBool("isOpenLight", FairyMovement.isOpenLight);
            }
        }
    }
}
