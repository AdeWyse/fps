using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : State
{
    public Patrol(NpcMove move): base(move)
    {
        name = STATE.PATROL;
    }

    public override void Enter()
    {
        move.InvokeRepeating("patrolMovement", 0f, 0.5f);
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (move.CheckPlayerInView())
        {
            nextState = new Pursue(move);
            stage = EVENT.EXIT;
        }

    }

    public override void Exit() {
        move.CancelInvoke();
        base.Exit();
    }
}
