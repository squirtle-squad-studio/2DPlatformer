using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEffect
{
    public bool isMissingComponents { get; protected set; }
    public Cooldown cooldownComponent;

    public BaseEffect()
    {
        cooldownComponent = new Cooldown(0);
    }

    /**
     * ApplyEffect()
     * Changes variables of certain scripts that needs.
     */
    public abstract void ApplyEffect();
    /**
     * EndEffect()
     * This method is called after the effect has ran out.
     * Please return the value of the original value.
     */
    public abstract void EndEffect();
}
