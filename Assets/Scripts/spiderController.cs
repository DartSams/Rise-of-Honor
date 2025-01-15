using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class spiderController : MonoBehaviour
{
    public NavMeshAgent agent;
    Vector3 velocity = Vector3.zero;
    List<Transform> spiderWaypoints = new List<Transform>();
    Transform currWaypoint;

    public float smoothDampTime = 0.1f; 

    // Start is called before the first frame update
    void Start()
    {
        GameObject spiderWaypointsLocations = GameObject.FindGameObjectWithTag("SpiderWaypointsLocation");
        foreach (Transform waypoint in spiderWaypointsLocations.transform)
        {
            spiderWaypoints.Add(waypoint);
        }

        if (spiderWaypoints.Count > 0)
        {
            currWaypoint = spiderWaypoints[Random.Range(0, spiderWaypoints.Count)];
            agent.SetDestination(currWaypoint.position);
        }
        agent.updatePosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending)
        {
            Transform nextWaypoint;
            do
            {
                nextWaypoint = spiderWaypoints[Random.Range(0, spiderWaypoints.Count)];
            } while (nextWaypoint == currWaypoint);

            currWaypoint = nextWaypoint;
            agent.SetDestination(currWaypoint.position);
        }

        transform.position = Vector3.SmoothDamp(transform.position, agent.nextPosition, ref velocity, smoothDampTime);
    }
}
