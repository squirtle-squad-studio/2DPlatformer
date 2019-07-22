using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Patrol : BaseState
{
    public Vector2 patrolLoc_left;
    public Vector2 patrolLoc_right;

    private bool isPatrolToTheRight;

    public event Action OnPatrolTurnAround;

    public Patrol(GameObject obj, EntityInput entityInputs, Vector2 left, Vector2 right) : base(obj,entityInputs)
    {
        patrolLoc_left = left;
        patrolLoc_right = right;
    }
    public Patrol(GameObject obj, EntityInput EntityInputs, Vector2 left, Vector2 right, bool isPatrolToTheRight) : base(obj, EntityInputs)
    {
        patrolLoc_left = left;
        patrolLoc_right = right;
        this.isPatrolToTheRight = isPatrolToTheRight;
    }

    public override void Tick()
    {
        PatrolAroundLoc();
    }
    private void PatrolAroundLoc()
    {
        if (isPatrolToTheRight)
        {
            PatrolTo(patrolLoc_right);
        }
        else
        {
            PatrolTo(patrolLoc_left);
        }
    }

    private void PatrolTo(Vector2 loc)
    {
        entityInputs.ResetKeyInputs();
        if (loc.x - obj.transform.position.x < 0.1 && loc.x - obj.transform.position.x > -0.1)
        {
            TurnAround();
        }
        else if (loc.x - obj.transform.position.x >= 0.1)
        {
            entityInputs.right = true;
        }
        else
        {
            entityInputs.left = true;
        }
    }

    private void TurnAround()
    {
        isPatrolToTheRight = !isPatrolToTheRight;
        PatrolTurnAround();
    }

    private void PatrolTurnAround()
    {
        if(OnPatrolTurnAround != null)
        {
            OnPatrolTurnAround();
        }
    }
}
