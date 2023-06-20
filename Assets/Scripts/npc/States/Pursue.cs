using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : State
{
    public Pursue(NpcMove move) : base(move)
    {
        name = STATE.PURSUE;
    }

    public override void Enter()
    {
        move.InvokeRepeating("PursuePlayer", 0f, 0.5f);
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

    public override void Exit()
    {
        move.CancelInvoke();
        base.Exit();
    }
}
