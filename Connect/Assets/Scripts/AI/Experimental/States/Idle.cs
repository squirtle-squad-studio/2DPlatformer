using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Idle:
 * This class basically does nothing
 */
public class Idle : BaseState
{

    public Idle(GameObject obj, EntityInput entityInputs) : base(obj, entityInputs)
    {

    }

    public override void Tick()
    {
        entityInputs.ResetKeyInputs();
    }
}
