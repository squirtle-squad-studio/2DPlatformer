using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTaker : MonoBehaviour
{
    private ListOfEffects listOfEffects;

    private void Start()
    {
        listOfEffects = new ListOfEffects();
    }

    public void AddEffectSlow(float percentage, float duration)
    {
        Slow s = (Slow)listOfEffects.Get(typeof(Slow));
        if(s == null)
        {
            s = new Slow(this.gameObject);
            if (s.isMissingComponents) return;
            listOfEffects.AddEffect(typeof(Slow), s);
        }
        s.percentage = percentage;
        s.cooldownComponent.NextCD(duration);
    }

    public void AddEffectDmgOverTime(int damage, float tickRate, float duration)
    {
        DamageOverTime s = (DamageOverTime)listOfEffects.Get(typeof(DamageOverTime));
        if(s == null)
        {
            s = new DamageOverTime(this.gameObject);
            if (s.isMissingComponents) return;
            listOfEffects.AddEffect(typeof(DamageOverTime), s);
        }
        s.damage = damage;
        s.tickRate = tickRate;
        s.cooldownComponent.NextCD(duration);
    }

    private void FixedUpdate()
    {
        foreach(var effect in listOfEffects.list)
        {
            if(effect.Value.cooldownComponent.isOnCD())
            {
                effect.Value.ApplyEffect();
            }
            else
            {
                effect.Value.EndEffect();
            }
        }
    }
}
