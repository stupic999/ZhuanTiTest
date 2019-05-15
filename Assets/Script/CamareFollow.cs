using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamareFollow : MonoBehaviour {

    public GameObject MainCamare;
    public GameObject Player;

	// Update is called once per frame
	void Update () {
        // hospital 左边-231.5 右边-213.5
        // Park 左边-109 右边 109
        // house 左边 223 377
        float Playerx = Player.transform.position.x;
        if (GameController.PlayerRoom == "Hospital")
        {
            if (Playerx > -231.5 && Playerx < -213.5)
            {
                FollowPlayer();
            }
        }
        else if (GameController.PlayerRoom == "Park")
        {
            if (Playerx > -109 && Playerx < 109)
            {
                FollowPlayer();
            }
        }
        else if (GameController.PlayerRoom == "House")
        {
            if (Playerx > 223 && Playerx < 377)
            {
                FollowPlayer();
            }
        }
    }

    public void FollowPlayer()
    {
        MainCamare.transform.position = new Vector3(Player.transform.position.x, 0, MainCamare.transform.position.z);
    }
}
