using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {

    public GameObject food;
    public GameObject spawnPointSelf;
    float foodSpawnTimer;
    int force;
    // Use this for initialization
    void Start () {
        if (spawnPointSelf.name == "CubeM")
        {
            force = 13;
        }
        else if (spawnPointSelf.name == "CubeL1" || spawnPointSelf.name == "CubeR1")
        {
            force = 15;
        }
        else
        {
            force = 25;
        }
        spawnPointSelf.transform.Translate(Vector3.left * force);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameControllerFood.isWin != true && GameControllerFood.isGameOver != true) 
        // 计算时间，时间到了，产生食物
        foodSpawnTimer += Time.deltaTime;
        if (foodSpawnTimer > 5)
        {
            Instantiate(food,transform.position,transform.rotation);
            foodSpawnTimer = 0;
        }
	}
}
