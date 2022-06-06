using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [HideInInspector] public PlayerInput _agentInput;
    [HideInInspector] public Rigidbody2D _rb2d;
    [HideInInspector] public AgentAnimation _animationManager;
    [HideInInspector] public AgentRenderer _agentRenderer;

    public State currentState;
    public State previousState;

    public State IdleState;

    [Header("State Debugging:")]
    public string stateName;    

    private void Awake()
    {
        _agentInput = this.GetComponentInParent<PlayerInput>();
        _rb2d = this.GetComponent<Rigidbody2D>();
        _animationManager = this.GetComponentInChildren<AgentAnimation>();
        _agentRenderer = this.GetComponentInChildren<AgentRenderer>();

        foreach (var state in this.GetComponentsInChildren<State>())
            state.InitializeState(this);
    }

    private void Start()
    {
        _agentInput.OnMovement += _agentRenderer.FaceDirection;

        TransitionToState(IdleState);
    }

    private void Update()
    {
        currentState?.StateUpdate();
    }

    private void FixedUpdate()
    {
        currentState?.StateFixedUpdate();
    }

    public void TransitionToState(State newState)
    {
        if (ReferenceEquals(newState, null)) return;
        currentState?.Exit();

        currentState = newState;
        currentState.Enter();

        DisplayState();
    }

    private void DisplayState()
    {
        stateName = currentState?.name ?? string.Empty;
    }
}
