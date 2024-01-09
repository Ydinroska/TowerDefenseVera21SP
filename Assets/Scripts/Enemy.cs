using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    
    [SerializeField] float speed = 5.0f;

    // get reference to the road
    [SerializeField] EnemyPath enemyPath; 

    // remember where to go
    int currentTargetWaypoint = 0;


    private void Update()
    {
        // block comments:    ctrl + k, ctrl + c 
        // unblock comments:  ctlr + k, ctrl + u 

        // look at the destination
        transform.LookAt(enemyPath.GetWaypoint(currentTargetWaypoint));

       // move to the destination
        transform.position = Vector3.MoveTowards(
            transform.position,                                    // where from
            enemyPath.GetWaypoint(currentTargetWaypoint).position, // where to
            speed * Time.deltaTime                                 // how fast
            );

        // are we close enough to the destination?
        if(Vector3.Distance(transform.position, 
            enemyPath.GetWaypoint(currentTargetWaypoint).position) < 0.2f)
        {
            // increment the current target waypoint
            currentTargetWaypoint++; 
        }

    }


}
