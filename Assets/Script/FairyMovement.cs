using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyMovement : MonoBehaviour {

    Vector3 movementH;
    Vector3 movementV;
    string PlayerFace = "L";
    public Animator PlayerAnim;

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
        if (GameController.isPause != true)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            // Player面向
            if (h > 0)
            {
                PlayerFace = "R";
            }
            if (h < 0)
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

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
            {
                PlayerAnim.SetBool("isFly", false);
            }
            else if (v != 0 || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
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
        }
    }

    public void Move(float h, float v)
    {
        movementH.Set(h, 0, 0);

        movementV.Set(0, v, 0);

        movementH = movementH.normalized * moveHSpd * Time.deltaTime;

        movementV= movementV.normalized * moveVSpd * Time.deltaTime;

        playerRb.MovePosition(transform.position + movementH + movementV);
    }
}
