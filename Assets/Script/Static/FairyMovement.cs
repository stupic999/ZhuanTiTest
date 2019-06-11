using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyMovement : MonoBehaviour {

    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    float h;
    float v;
    Rigidbody playerRb;
    public float moveHSpd;
    public float moveVSpd;
    public Animator PlayerAnim;
    public GameObject Player;
    public JoyStickController joyStickController;


    public void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        if (!gameControllerScriptableObject.isNight)
        {
            gameControllerScriptableObject.isOpenLight = false;
            PlayerAnim.SetBool("isOpenLight", gameControllerScriptableObject.isOpenLight);
            PlayerAnim.SetBool("isNight", false);
        }

        if (gameControllerScriptableObject.isPause || gameControllerScriptableObject.isOpenLight)
        {
            h = 0;
            v = 0;
        }
        if (!gameControllerScriptableObject.isPause && gameControllerScriptableObject.isTalkWithBoy)
        {
            h = joyStickController.GetHorizontal();
            v = joyStickController.GetVertical();

            // Player面向
            if (h > 0)
            {
                gameControllerScriptableObject.PlayerFace = "R";
            }
            else if (h < 0)
            {
                gameControllerScriptableObject.PlayerFace = "L";
            }

            if (gameControllerScriptableObject.PlayerFace == "L")
            {
                Player.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                Player.transform.eulerAngles = new Vector3(0, 180, 0);
            }

            if (h != 0)
            {
                PlayerAnim.SetBool("isLeftRight", true);
            }
            else
            {
                PlayerAnim.SetBool("isLeftRight", false);
            }

            if (v != 0)
            {
                PlayerAnim.SetBool("isFly", true);
            }
            else
            {
                PlayerAnim.SetBool("isFly", false);
            }
            Move(h, v);
        }
        else
        {
            PlayerAnim.SetBool("isFly", false);
            PlayerAnim.SetBool("isLeftRight", false);
        }
    }

    public void Move(float h, float v)
    {
        Vector3 movement = new Vector3(h/4.5f,v/9,0);
        playerRb.MovePosition(transform.position + movement);
        Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -3);
    }
}
