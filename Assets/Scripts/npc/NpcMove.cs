using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NpcMove : MonoBehaviour
{
    private WaypointManager waypointManager;
    private List<Transform> waypoints = new List<Transform>();
    private Animator animator;
    private NavMeshAgent agent;
    public bool move = false;
    public List<int> route = new List<int>();
    private int routePosition = 0;
    private int startCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        waypointManager = GameObject.Find("Waypoints").GetComponent<WaypointManager>();
        animator = gameObject.GetComponentInChildren<Animator>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startCount == 0)
        {
            waypoints = waypointManager.waypoints;
            route = makeRoute();
            startCount++;

        }
            goToWaypoint();
    }

    private void goToWaypoint()
    {
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending && routePosition < route.Count)
        {
            agent.SetDestination(waypointManager.waypoints[route[routePosition]].position);
            routePosition++;
        }
        if(routePosition == route.Count)
        {
            move = false;
        }

    }

    private List<int> makeRoute()
    {
        
        List<int> positions = new List<int>();
        int waypointsSize = waypoints.Count;
            int nextWaypoint = Random.Range(0, waypointsSize);
        while (positions.Count < waypoints.Count)
        {
            if(!positions.Contains(nextWaypoint))
            {
                positions.Add(nextWaypoint);
                
            }
            nextWaypoint = Random.Range(0, waypointsSize);
        }
            

        return positions;
    }
}
