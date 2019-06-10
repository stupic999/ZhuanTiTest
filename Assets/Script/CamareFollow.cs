using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamareFollow : MonoBehaviour {

    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    public GameObject Player;
    public GameObject MainCamare;

    void Update()
    {
        float Playerx = Player.transform.position.x;
        if (gameControllerScriptableObject.PlayerRoom == "Hospital")
        {
            if (Playerx > -231.5 && Playerx < -213.5)
            {
                FollowPlayer();
            }
        }
        else if (gameControllerScriptableObject.PlayerRoom == "Park")
        {
            if (Playerx > -109 && Playerx < 109)
            {
                FollowPlayer();
            }
        }
        else if (gameControllerScriptableObject.PlayerRoom == "House")
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
