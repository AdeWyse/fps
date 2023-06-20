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
    private int persueCount = 0;

    private GameObject player;

    float visisionDistance = 5.0f;
    float visionAngle = 30.0f;
    float shootDistance = 7.0f;
    float walkSpeed = 1.5f;
    float runSpeed = 3f;
    void Start()
    {
        waypointManager = GameObject.Find("Waypoints").GetComponent<WaypointManager>();
        animator = gameObject.GetComponentInChildren<Animator>();
        agent = gameObject.GetComponent<NavMeshAgent>();

        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void goToWaypointWalk()
    {
        if (agent.remainingDistance <= agent.stoppingDistance && routePosition < route.Count)
        {
            agent.SetDestination(waypointManager.waypoints[route[routePosition]].position);
            routePosition++;
        }
        if(routePosition == route.Count)
        {
            move = false;
            startCount = 0;
        }
        if (move)
        {
            animator.SetFloat("Speed", 0.0f);
        }
        else
        {
            animator.SetFloat("Speed", 0.34f);
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

    public void patrolMovement()
    {
        if (startCount == 0)
        {
            waypoints = waypointManager.waypoints;
            route = makeRoute();
            agent.speed = walkSpeed;
            startCount++;

        }
        goToWaypointWalk();
    }

    public bool CheckPlayerInView()
    {
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        if(distance < visisionDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PursuePlayer()
    {
        if(persueCount == 0)
        {
            animator.SetFloat("Speed", 0.7f);
            agent.speed = runSpeed;
            persueCount++;
        }
        Debug.Log("AQYUIO");
    }
}
