using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaypointMover : MonoBehaviour
{
    //Reference the waypoint objects
    [SerializeField] public Waypoint waypoints;
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float distanceAmount = .001f;

    private Vector3 lastWaypointPos = new Vector3(-27f, 1.15f, -1.86f);

    //Current waypoint to move towards
    private Transform currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {

        //Set init position to start of track
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        //Set next waypoint target
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceAmount)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            transform.LookAt(currentWaypoint);
        }

        if (gameObject.transform.position.x < lastWaypointPos.x)
        {
            Destroy(gameObject);
        }
    }
}
