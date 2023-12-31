using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State 
{
   public enum STATE
    {
        IDLE, PATROL, PURSUE, ATTACK, END, SEARCH
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;

    protected NpcMove move;

    protected State nextState; 

    public State(NpcMove move)
    {
        this.move = move;
    }

    public virtual void Enter()
    {
        stage = EVENT.UPDATE;
    }

    public virtual void Update()
    {
        stage = EVENT.UPDATE;
    }

    public virtual void Exit()
    {
        stage = EVENT.EXIT;
    }

    public State Process()
    {
        if (stage == EVENT.ENTER)
        {
            Enter();
        }

        if (stage == EVENT.UPDATE)
        {
            Update();
        }

        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }
}
