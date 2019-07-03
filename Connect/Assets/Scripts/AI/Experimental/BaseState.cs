using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected GameObject obj;
    public BaseState(GameObject obj)
    {
        this.obj = obj;
    }
    public virtual void Tick()
    {

    }
}
