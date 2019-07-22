using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : BaseEffect
{
    public int damage;
    public float tickRate;

    private Cooldown nextTick;
    private Health healthComponent;
    public DamageOverTime(GameObject obj) : base()
    {
        healthComponent = obj.GetComponent<Health>();
        if(healthComponent == null)
        {
            isMissingComponents = true;
            return;
        }
        nextTick = new Cooldown(0);
        this.tickRate = 0f;
    }

    public DamageOverTime(GameObject obj, float tickRate) : base()
    {
        healthComponent = obj.GetComponent<Health>();
        nextTick = new Cooldown(0);
        this.tickRate = tickRate;
    }

    public override void ApplyEffect()
    {
        if(!nextTick.isOnCD())
        {
            healthComponent.MyHealth -= damage;
            nextTick.NextCD(tickRate);
        }
    }

    public override void EndEffect()
    {
        nextTick.NextCD(0);
    }
}
