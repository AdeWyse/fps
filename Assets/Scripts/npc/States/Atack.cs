using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack: State
{
    public Atack(NpcMove move) : base(move)
    {
        name = STATE.PURSUE;
    }

    public override void Enter()
    {
        move.InvokeRepeating("AttackPlayer", 0f, 0.5f);
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
       if (!move.CheckPlayerInAttackDistance())
        {
            nextState = new Pursue(move);
            stage = EVENT.EXIT;
        }
        if (!move.CheckPlayerInView())
        {
            nextState = new Patrol(move);
            stage = EVENT.EXIT;
        }
        if (!move.CheckAlive())
        {
            nextState = new Die(move);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        move.ResetAnimations();
        move.attackCount = 0;
        move.CancelInvoke();
        base.Exit();
    }
}
