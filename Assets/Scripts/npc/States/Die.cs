using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : State
{
    public Die(NpcMove move) : base(move)
    {
        name = STATE.PATROL;
    }

    public override void Enter()
    {
        move.Die();
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

    }

    public override void Exit()
    {
        move.CancelInvoke();
        base.Exit();
    }
}
