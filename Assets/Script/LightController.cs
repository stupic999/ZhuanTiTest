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

    void Awake()
    {
        LightImage = GetComponent<Image>();
        LightImage.sprite = Resources.Load<Sprite>("LightOff");
        PlayerLight.SetActive(false);
        gameControllerScriptableObject.isOpenLight = false;
        PlayerAnim.SetBool("isOpenLight", gameControllerScriptableObject.isOpenLight);
    }

    void Update()
    {
        if (gameControllerScriptableObject.isOpenLight)
        {
            LightImage.sprite = Resources.Load<Sprite>("LightOn");
            PlayerLight.SetActive(true);
            PlayerAnim.SetBool("isOpenLight", gameControllerScriptableObject.isOpenLight);
            MoveUI.SetActive(false);
        }
        else
        {
            LightImage.sprite = Resources.Load<Sprite>("LightOff");
            PlayerLight.SetActive(false);
            PlayerAnim.SetBool("isOpenLight", gameControllerScriptableObject.isOpenLight);
            MoveUI.SetActive(true);
        }
    }

    public void ChangeLight()
    {
        if (!gameControllerScriptableObject.isPause)
        {
            gameControllerScriptableObject.isOpenLight = !gameControllerScriptableObject.isOpenLight;
        }
    }
}
