using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BaseState
{
    public Attack(GameObject obj, EntityInput entityInputs) : base(obj, entityInputs)
    { 
    }

    public override void Tick()
    {
        entityInputs.ResetKeyInputs();
        entityInputs.basicAttack = true;
    }
}
