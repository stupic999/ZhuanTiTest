using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyMovement : MonoBehaviour {

    Vector3 movementH;
    Vector3 movementV;
    public float moveHSpd;
    public float moveVSpd;
    Rigidbody playerRb;

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
            Move(h, v);
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
