using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private NpcMove move;
    private State currentState;
    // Start is called before the first frame update
    void Start()
    {
        move = gameObject.GetComponent<NpcMove>();
        currentState = new Patrol(move);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
    }
}
