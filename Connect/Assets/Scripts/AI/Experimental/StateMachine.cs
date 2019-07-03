using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public Type currentState { get; set; }
    public Dictionary<Type, BaseState> listOfPossibleStates { get; private set; }

    private Type firstState;

    protected void Awake()
    {
        listOfPossibleStates = new Dictionary<Type, BaseState>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("--------Before---------");
        Debug.Log(currentState);
        Debug.Log(firstState);
        Debug.Log(listOfPossibleStates.Count);
        Debug.Log(this.gameObject);
        Debug.Log("--------Before---------");

        //Checks if there is current state
        if (listOfPossibleStates == null) { return; }
        else
        {
            if (currentState == null)
            {
                if (firstState != null)
                {
                    currentState = firstState;
                }
                else
                {
                    return;
                }
            }
        }
        Debug.Log("---------After--------");
        Debug.Log(currentState);
        Debug.Log(firstState);
        Debug.Log(listOfPossibleStates.Count);
        Debug.Log("---------After--------");


        listOfPossibleStates[currentState].Tick();

    }

    public void Transition(Type state)
    {
        if (currentState == state) return;
        if (firstState == null) firstState = state;
        currentState = state;
    }
}
