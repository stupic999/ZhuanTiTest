using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {

    public GameObject food;
    public  GameObject spawnPointSelf;
    float foodSpawnTimer;    

    // Use this for initialization
    void Start () {
        spawnPointSelf.transform.Translate(Vector3.left *10);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameController.isWin != true && GameController.isGameOver != true) 
        // 计算时间，时间到了，产生食物
        foodSpawnTimer += Time.deltaTime;
        if (foodSpawnTimer > 5)
        {
            Instantiate(food,transform.position,transform.rotation);
            foodSpawnTimer = 0;
        }
	}
}
