using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFollow : MonoBehaviour {

    [SerializeField]
    GameControllerScriptableObject gameControllerScriptableObject;
    Vector3 offset;
    public Transform target;    

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = target.position - transform.position;
    }

    void Update()
    {
        if(!gameControllerScriptableObject.ghostDie)
        transform.position = target.position - offset;
    }
}
