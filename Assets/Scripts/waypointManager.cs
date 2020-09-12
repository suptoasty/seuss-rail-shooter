using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public waypoint[] waypoints;
    public int destPoint = 0;
    public bool stop = false;
    public float movementSpeed = 1.0f;

    public void FixedUpdate() {
        Vector3 point = waypoints[destPoint].transform.position;
        point = new Vector3(Mathf.Round(point.x), Mathf.Round(point.y), Mathf.Round(point.z));
        Vector3 playerPoint = gameObject.transform.position;
        GameObject[] balloons = GameObject.FindGameObjectsWithTag("balloon");
        // Debug.Log(destPoint);

        // move to point until there
        if( playerPoint.z != point.z &&
            playerPoint.x != point.x) 
        {
            gameObject.transform.position = Vector3.MoveTowards(playerPoint, point, movementSpeed * Time.fixedDeltaTime);
        } 
        //if there and it is a stopping point skip
        else if(balloons.Length == 0) 
        {
            GotoNextPoint();
        }

    }
    public void GotoNextPoint() {
        if(waypoints.Length == 0) return;
        if(destPoint == waypoints.Length) destPoint = waypoints.Length;
        destPoint = (destPoint + 1) % waypoints.Length;

    }
}
