﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [Header("State")]
    [SerializeField] private Enemy_State currentState;
    [SerializeField] private Enemy_State  remainState;

 

    private void Update()
    {
        currentState.EvaluateState(this);
    }


    public void TransitionToState(Enemy_State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }

}