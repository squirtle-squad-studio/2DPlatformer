using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AIInput))]
public class ZombieController : StateController
{
    [Header("Patrol")]
    [SerializeField] private float idleTimeBeforeTurnAround;
    [SerializeField] private Vector2 patrolLoc_left;
    [SerializeField] private Vector2 patrolLoc_right;

    [Header("Player Detectors")]
    [SerializeField] private PlayerDetector detector;
    [SerializeField] private PlayerDetector attackRange;

    [Header("Debug")]
    [SerializeField] private Color color;
    [SerializeField] private bool showDetection;
    [SerializeField] private float radius;

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
        Patrol patrol = new Patrol(this.gameObject, aiInput, patrolLoc_left, patrolLoc_right);
        patrol.OnPatrolTurnAround += OnPatrolSwitch;

        stateMachine.listOfPossibleStates.Add(typeof(Idle), new Idle(this.gameObject, aiInput));
        stateMachine.listOfPossibleStates.Add(typeof(Patrol), patrol);
        stateMachine.listOfPossibleStates.Add(typeof(Chase), new Chase(this.gameObject, aiInput, detector));
        stateMachine.listOfPossibleStates.Add(typeof(Attack), new Attack(this.gameObject, aiInput));
        stateMachine.currentState = typeof(Idle);
    }

    protected override void HandleState()
    {
        /*
         * Prioritize on finding a player and chase them.
         * If players aren't found, then go back to idle mode.
         */
        if (stateMachine.currentState == typeof(Idle))
        {
            if (!idleToPatrolTimer.isOnCD())
            {
                stateMachine.Transition(typeof(Patrol));
            }
            else if (detector.players.Count > 0)
            {
                stateMachine.Transition(typeof(Chase));
            }
        }
        else if(stateMachine.currentState == typeof(Patrol))
        {
            if (detector.players.Count > 0)
            {
                stateMachine.Transition(typeof(Chase));
            }
        }
        else if(stateMachine.currentState == typeof(Chase))
        {
            if(detector.players.Count == 0)
            {
                stateMachine.Transition(typeof(Idle));
            }
            else if (attackRange.players.Count != 0)
            {
                stateMachine.Transition(typeof(Attack));
            }
        }
        else if(stateMachine.currentState == typeof(Attack))
        {
            if(attackRange.players.Count == 0 && detector.players.Count == 0)
            {
                stateMachine.Transition(typeof(Patrol));
            }
            else if(attackRange.players.Count == 0 && detector.players.Count != 0)
            {
                stateMachine.Transition(typeof(Chase));
            }
        }
    }

    /*
     * Switch to Idle state for a while and continue later
     */
    public void OnPatrolSwitch()
    {
        idleToPatrolTimer.NextCD(idleTimeBeforeTurnAround);
        stateMachine.Transition(typeof(Idle));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = this.color;
        Gizmos.DrawWireSphere(patrolLoc_left, radius);
        Gizmos.DrawWireSphere(patrolLoc_right, radius);
    }
}
