using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFollow : MonoBehaviour {

    Vector3 offset;
    public Transform target;    

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = target.position - transform.position;
    }

    void Update()
    {
        if(!Ghost.ghostDie)
        transform.position = target.position - offset;
    }
}
