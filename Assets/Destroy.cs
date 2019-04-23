using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    // 能量条增减

    float spd=1;
    Rigidbody me;
    Vector3 movement;

	// Use this for initialization
	void Start () {
        me = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {        
        if (GameController.isGameOver != true)
        {
            // 移动
            movement.Set(0, 0, 1);
            movement = movement * spd * Time.deltaTime;
            me.MovePosition(transform.position + movement);
        }
	}

    public void OnTriggerStay(Collider destroyer)
    {
        if (GameController.isGameOver != true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (destroyer.tag == "Destroyer")
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
