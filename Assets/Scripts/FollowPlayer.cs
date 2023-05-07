using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour 
{    
    public Transform leader;

    Vector3 _followOffset;

    void Start()
    {
        leader = GameObject.Find("Player").transform;
        //initial offset
        _followOffset = transform.position - leader.position;
    }

    void LateUpdate () 
    {
        Vector3 targetPosition = leader.position + _followOffset;
        
        //Keep y position the same
        targetPosition.y = transform.position.y;

        transform.position += targetPosition - transform.position;
    }
}
