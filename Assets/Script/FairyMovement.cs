using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyMovement : MonoBehaviour {

    public static  Vector3 movementH;
    static Vector3 movementV;
    public static string PlayerFace = "L";
    public Animator PlayerAnim;
    public static bool isOpenLight; 
    float h;
    float v;

    public float moveHSpd;
    public float moveVSpd;
    
    Rigidbody playerRb;
    public GameObject Player;
    

    public void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        if (!ClockTimer.isNight)
        {
            isOpenLight = false;
            PlayerAnim.SetBool("isOpenLight", isOpenLight);
            PlayerAnim.SetBool("isNight", false);
        }

        if (GameController.isPause || isOpenLight)
        {
            h = 0;
            v = 0;
        }
        if (!GameController.isPause && GameController.isTalkWithBoy)
        {
            
            // Player面向
            if (h > 0)
            {
                PlayerFace = "R";
            }
            else if (h < 0)
            {
                PlayerFace = "L";
            }

            if (PlayerFace == "L")
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
        movementH.Set(h, 0, 0);

        movementV.Set(0, v, 0);

        movementH = movementH.normalized * moveHSpd * Time.deltaTime;

        movementV= movementV.normalized * moveVSpd * Time.deltaTime;

        playerRb.MovePosition(transform.position + movementH +movementV);
        Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -3);
    }

    public void MoveUpPress()
    {
        v = 1;
    }
    public void MoveDownPress()
    {
        v = -1;
    }
    public void MoveVRelease()
    {
        v = 0;
    }
    public void MoveLeftPress()
    {
        h = -1;
    }
    public void MoveRightPress()
    {
        h = 1;
    }
    public void MoveHRelease()
    {
        h = 0;
    }
    public void MoveUpLeftPress()
    {
        h = -1;
        v = 1;
    }
    public void MoveUpRightPress()
    {
        h = 1;
        v = 1;
    }
    public void MoveDownLeftPress()
    {
        h = -1;
        v = -1;
    }
    public void MoveDownRightPress()
    {
        h = 1;
        v = -1;
    }
    public void MoveTwoRelease()
    {
        h = 0;
        v = 0;
    }
}
