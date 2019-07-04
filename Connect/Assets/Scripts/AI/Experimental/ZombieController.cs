using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AIInput))]
public class ZombieController : StateController
{
    public bool isIdle;
    [SerializeField] private Vector2 patrolLoc_left;
    [SerializeField] private Vector2 patrolLoc_right;

    private AIInput aiInput;
    private Cooldown idleToPatrolTimer;

    protected override void Awake()
    {
        base.Awake();
        idleToPatrolTimer = new Cooldown(0);
        aiInput = GetComponent<AIInput>();

    }
    protected override void Start()
    {
        stateMachine.listOfPossibleStates.Add(typeof(Idle), new Idle(this.gameObject, aiInput));
        stateMachine.listOfPossibleStates.Add(typeof(Patrol), new Patrol(this.gameObject, aiInput, patrolLoc_left, patrolLoc_right));
        stateMachine.currentState = typeof(Patrol);
    }

    protected override void HandleState()
    {
        if (isIdle) stateMachine.Transition(typeof(Idle));
        else { stateMachine.Transition(typeof(Patrol)); }

        //if (stateMachine.currentState == typeof(Idle))
        //{
        //    if (!idleToPatrolTimer.isOnCD())
        //    {
        //        stateMachine.Transition(typeof(Patrol));
        //    }
        //}
        // This doesn't work that well because the cooldown gets applied multiple times for a turn around.
        // Maybe using an event would be better.
        //else if (stateMachine.currentState == typeof(Patrol))
        //{
        //    if ((Mathf.Abs(patrolLoc_left.x - transform.position.x)) < 0.01 || (Mathf.Abs(patrolLoc_right.x - transform.position.x)) < 0.01)
        //    {
        //        idleToPatrolTimer.NextCD(0.5f);
        //        stateMachine.Transition(typeof(Idle));
        //    }
        //}
    }
}
