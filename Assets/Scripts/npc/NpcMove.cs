using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class NpcMove : MonoBehaviour
{
    private WaypointManager waypointManager;
    private List<Transform> waypoints = new List<Transform>();
    private Animator animator;
    private NavMeshAgent agent;
    private Actions animatorActions;
    private PlayerController animController;
    public bool move = false;
    public List<int> route = new List<int>();
    private int routePosition = 0;
    public int startCount = 0;
    public int pursueCount = 0;
    public int attackCount = 0;

    private GameObject player;
    private PlayerHealth playerHealth;

    float visisionDistanceOriginal = 10.0f;
    float visisionDistance;
    float visionAngle = 90.0f;
    float shootDistance = 4.0f;
    float walkSpeed = 1.5f;
    float runSpeed = 3f;

    public int life = 50;
    public bool searching = false;

    private GameManager gameManager;
    void Start()
    {
        visisionDistance = visisionDistanceOriginal;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        waypointManager = GameObject.Find("Waypoints").GetComponent<WaypointManager>();
        animator = gameObject.GetComponentInChildren<Animator>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        animatorActions = gameObject.GetComponentsInChildren<Actions>()[0];
        animController = gameObject.GetComponentsInChildren<PlayerController>()[0];

        animController.SetArsenal("Rifle");

        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        
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
        if(distance < visisionDistance && CheckPlayerInAngle())
        {
            return true;
        }
        else
        {
            return false;

        }
    }

    public bool CheckPlayerInAttackDistance()
    {
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
       
        if (distance < shootDistance && CheckPlayerInAngle())
        {
            return true;
        }
        else
        {
            return false;

        }
    }

    public bool CheckPlayerInAngle()
    {

        Vector3 direction = player.transform.position - gameObject.transform.position;
        float angle = Vector3.Angle(direction, gameObject.transform.forward);

        if (angle < visionAngle)
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
        if (pursueCount == 0)
        {
            animator.SetFloat("Speed", 0.7f);
            agent.speed = runSpeed;
            pursueCount++;
            agent.isStopped = false;
        }
        agent.SetDestination(player.transform.position) ;
    }

    public void AttackPlayer()
    {
        if (attackCount == 0)
        {
            animatorActions.Aiming();
            attackCount++;
            agent.isStopped = true;
        }
        gameObject.transform.LookAt(player.transform);
        animatorActions.Attack();
        Gun gun = gameObject.GetComponentInChildren<Gun>();
        gun.shootRayNpc();
    }

    public void ResetAnimations()
    {
        animator.SetBool("Aiming", false); 
    }

    public void TakeDamage(int damage)
    {
        animatorActions.Damage();
        life = life - damage;
        
    }

    public  bool CheckAlive()
    {
        if(life < 0)
        {
            return false;
        }
        return true;
    }

    public void Die()
    {
        animatorActions.Death();
        gameObject.GetComponent<Collider>().enabled = false;
        Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
        agent.isStopped = true;
        gameManager.npcCount--;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hit")
        {
            visisionDistance =  3 * visisionDistanceOriginal;
            gameObject.transform.LookAt(player.transform);
            Invoke("ResetVision", 5.0f);

        }
    }

    private void ResetVision()
    {
        visisionDistance = visisionDistanceOriginal;
    }
}
