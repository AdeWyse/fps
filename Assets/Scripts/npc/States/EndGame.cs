using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : State
{
    public EndGame(NpcMove move) : base(move)
    {
        name = STATE.END;
    }

    public override void Enter()
    {
        move.CancelInvoke();
        move.ResetAnimations();
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

    }

    public override void Exit()
    {
        
        base.Exit();
    }
}
