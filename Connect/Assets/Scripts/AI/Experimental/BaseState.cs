using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected GameObject obj;
    protected AIInput aiInput;

    public BaseState(GameObject obj, AIInput aiInput)
    {
        this.obj = obj;
        this.aiInput = aiInput;
    }
    public virtual void Tick()
    {

    }
}
