using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
/**
 * Assume that this list have all the effects (Gets added if it's not there).
 */
public class ListOfEffects
{
    public Dictionary<Type, BaseEffect> list { get; private set; }

    public ListOfEffects()
    {
        list = new Dictionary<Type, BaseEffect>();
    }

    public void AddEffect(Type t, BaseEffect effect)
    {
        if(!list.ContainsKey(t))
        {
            list.Add(t, effect);
        }
    }

    public BaseEffect Get(Type t)
    {
        if(!list.ContainsKey(t))
        {
            return null;
        }

        return list[t];
    }
}
