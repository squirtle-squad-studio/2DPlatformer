using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : BaseEffect
{
    public int damage;

    public DamageOverTime(GameObject obj) : base()
    {
        // Grabs obj's component
    }

    public override void ApplyEffect()
    {
        Debug.Log("You got hit " + damage);
    }

    public override void EndEffect()
    {
    }
}
