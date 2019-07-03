using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInput : MonoBehaviour
{
    public AIControls aiControls { get; private set; }

    private void Awake()
    {
        aiControls = new AIControls();
    }
}
