using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    GameManager gameManager;
    private NpcMove move;
    private State currentState;
    private int running= 0;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        move = gameObject.GetComponent<NpcMove>();
        currentState = new Patrol(move);
    }

    // Update is called once per frame
    void Update()
    {
        running = gameManager.running;
        if(running == 0)
        {
            currentState = currentState.Process();

        }
    }
}
