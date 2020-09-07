using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointManager : MonoBehaviour {
    public waypoint[] waypoints;
    private int destPoint = 0;
    public bool stop = false;
    public float movementSpeed = 1.0f;

    public void FixedUpdate() {
        Vector3 point = waypoints[destPoint].transform.position;
        point = new Vector3(Mathf.Round(point.x), Mathf.Round(point.y), Mathf.Round(point.z));
        Vector3 playerPoint = gameObject.transform.position;

        if( playerPoint.z != point.z &&
            playerPoint.x != point.x) 
        {
            gameObject.transform.position = Vector3.MoveTowards(playerPoint, point, movementSpeed * Time.fixedDeltaTime);

        } else if(!stop) {

            GotoNextPoint();
        }
    }

    public void GotoNextPoint() {
        if(waypoints.Length == 0) return;

        waypoint newPoint = waypoints[destPoint];
        if(newPoint.stop) {
            this.stop = true;
            return;
        }

        destPoint = (destPoint + 1) % waypoints.Length;
    }


}