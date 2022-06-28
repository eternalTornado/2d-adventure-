using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFactory : MonoBehaviour
{
    [SerializeField] State Idle;
    [SerializeField] State Move;
    [SerializeField] State Jump;
    [SerializeField] State Fall;
    [SerializeField] State Climbing;
    [SerializeField] State Attack;

    public State GetState(StateType type)
    {
        switch (type)
        {
            case StateType.Idle: return Idle;
            case StateType.Move: return Move;
            case StateType.Jump: return Jump;
            case StateType.Fall: return Fall;
            case StateType.Climbing: return Climbing;
            case StateType.Attack: return Attack;
        }

        return null;
    }

    public void InitializeStates(Agent agent)
    {
        foreach (var state in agent.GetComponentsInChildren<State>())
            state.InitializeState(agent);
    }
}

public enum StateType
{
    Idle,
    Move,
    Jump,
    Fall,
    Climbing,
    Attack
}
