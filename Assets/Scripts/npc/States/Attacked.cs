using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacked: State
{
    GameManager gameManager;
    public Attacked(NpcMove move) : base(move)
    {
        name = STATE.SEARCH;
    }

    public override void Enter()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        move.InvokeRepeating("React", 0f, 0.5f);
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
        if (!move.CheckAlive())
        {
            nextState = new Die(move);
            stage = EVENT.EXIT;
        }
        if (gameManager.playerHealth <= 0)
        {
            nextState = new EndGame(move);
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
