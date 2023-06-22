using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFolowwer : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int waypointIndex = 0;
    [SerializeField] float speed = 1.0f;
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < 0.1f)
        {
            waypointIndex++;
            waypointIndex = waypointIndex % 2;
        }   
    }
}
