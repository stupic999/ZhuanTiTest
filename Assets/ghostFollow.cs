using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostFollow : MonoBehaviour {

    public Transform target;
    private Vector3 offset;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!ghost.ghostDie)
        transform.position = target.position - offset;
    }
}
