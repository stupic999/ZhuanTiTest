using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    // 能量条增减
    float moveSpeed=2.5f;

    // Update is called once per frame
    void Update()
    {        
        if (GameController.isGameOver != true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.Self);
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
