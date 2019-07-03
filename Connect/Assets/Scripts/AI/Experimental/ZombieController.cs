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
    //private Cooldown idleToPatrolTimer;

    protected override void Awake()
    {
        base.Awake();
        aiInput = GetComponent<AIInput>();

    }
    protected override void Start()
    {
        stateMachine.listOfPossibleStates.Add(typeof(Idle), new Idle(this.gameObject));
        stateMachine.listOfPossibleStates.Add(typeof(Patrol), new Patrol(this.gameObject, aiInput, patrolLoc_left, patrolLoc_right));
    }

    protected override void HandleState()
    {
        if (isIdle)
        {
            stateMachine.Transition(typeof(Idle));
        }
        else
        {
            stateMachine.Transition(typeof(Patrol));
        }        

    }
}
