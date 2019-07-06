using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BaseState
{
    public Attack(GameObject obj, AIInput aiInput) : base(obj, aiInput)
    { 
    }

    public override void Tick()
    {
        aiInput.aiControls.ResetKeyInputs();
        aiInput.aiControls.basic_attack = true;
    }
}
