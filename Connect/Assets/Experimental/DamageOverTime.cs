using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : BaseEffect
{
    public int damage;

    private Cooldown nextTick;
    public DamageOverTime(GameObject obj) : base()
    {
        // Grabs obj's component

        nextTick = new Cooldown(0);
    }

    public override void ApplyEffect()
    {
        if(!nextTick.isOnCD())
        {
            Debug.Log("You got hit " + damage); // Hit

            nextTick.NextCD(1);
        }
    }

    public override void EndEffect()
    {
        nextTick.NextCD(0);
    }
}
