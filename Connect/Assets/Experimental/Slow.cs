using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : BaseEffect
{
    [Range(0,1)] public float percentage;
    public float baseRunSpeed;
    public float baseWalkSpeed;
    private Movement movementComponent;

    public Slow(GameObject obj) : base()
    {
        this.movementComponent = obj.GetComponent<Movement>(); // [Problem] This assumes that our object already have the component.
        if(movementComponent == null)
        {
            isMissingComponents = true;
            return;
        }
        baseRunSpeed = movementComponent.runVelocity.data;
        baseWalkSpeed = movementComponent.walkVelocity.data;
    }

    public override void EndEffect()
    {
        movementComponent.runVelocity.data = baseRunSpeed;
        movementComponent.walkVelocity.data = baseWalkSpeed;
    }

    public override void ApplyEffect()
    {
        movementComponent.runVelocity.data = baseRunSpeed * (1 - percentage);
        movementComponent.walkVelocity.data = baseWalkSpeed * (1 - percentage);
    }
}
