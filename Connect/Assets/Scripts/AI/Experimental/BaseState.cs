using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected GameObject obj;
    protected EntityInput entityInputs;

    public BaseState(GameObject obj, EntityInput aiInput)
    {
        this.obj = obj;
        this.entityInputs = aiInput;
    }
    public virtual void Tick()
    {

    }
}
