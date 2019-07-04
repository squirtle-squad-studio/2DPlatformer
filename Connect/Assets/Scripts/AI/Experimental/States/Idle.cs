using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Idle:
 * This class basically does nothing
 */
public class Idle : BaseState
{

    public Idle(GameObject obj, AIInput aiInput) : base(obj, aiInput)
    {

    }

    public override void Tick()
    {
        aiInput.aiControls.ResetKeyInputs();
    }
}
