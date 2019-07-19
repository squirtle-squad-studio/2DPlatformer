using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTaker : MonoBehaviour
{
    public bool applyEffect; // Testing wise: 

    private ListOfEffects listOfEffects;

    public float temp;

    private Movement movementComponent;

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

    public void AddEffectDmgOverTime(int damage, float duration)
    {
        DamageOverTime s = (DamageOverTime)listOfEffects.Get(typeof(DamageOverTime));
        if(s == null)
        {
            s = new DamageOverTime(this.gameObject);
            if (s.isMissingComponents) return;
            listOfEffects.AddEffect(typeof(DamageOverTime), s);
        }
        s.damage = damage;
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

        // Applying effect using bool
        if (applyEffect)
        {
            AddEffectSlow(0.75f, 10);
            AddEffectDmgOverTime(1, 10);
            // listOfEffects[typeof(Slow)].cooldownComponent.NextCD(10);
        }

        //// Tick()
        //if (effect.cooldownComponent.isOnCD())
        //{
        //    temp = effect.cooldownComponent.NextCastTime;
        //    effect.ApplyEffect();
        //}
        //else
        //{
        //    effect.EndEffect();
        //}
    }
}
