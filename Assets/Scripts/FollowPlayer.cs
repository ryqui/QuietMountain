using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour 
{   
    private Transform leader;

    void Start()
    {
        leader = GameObject.Find("Player").transform;
        //transform.position = new Vector3(leader.transform.position.x, transform.position.y, leader.transform.position.z);
        //initial offset
        transform.position = new Vector3(leader.transform.position.x, transform.position.y, leader.transform.position.z);
    }

    void LateUpdate ()
    {
        Vector3 targetPosition = leader.position;
        
        //Keep y position the same
        targetPosition.y = transform.position.y;

        transform.position += targetPosition - transform.position;
    }
}
