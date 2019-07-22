using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public abstract class StateController : MonoBehaviour
{
    protected StateMachine stateMachine;
    protected virtual void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        HandleState();
    }

    protected virtual void HandleState()
    {

    }
}
