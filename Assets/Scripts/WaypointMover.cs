using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaypointMover : MonoBehaviour
{
    //Reference the waypoint objects
    [SerializeField] private float speed = 3f;
    [SerializeField] private Transform target;

    private int wavepointIndex;

    private void Start()
    {
        target = Waypoint.points[0];
        transform.position = target.position;
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
            GetNextWaypoint();
    }

    private void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoint.points.Length - 1)
        {
            Destroy(gameObject);
            PlayerStats.lives -= 1;
        }

        wavepointIndex++;
        target = Waypoint.points[wavepointIndex];
        transform.LookAt(target);
    }
}
