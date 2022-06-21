using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WeaponSystem;

public class Agent : MonoBehaviour
{
    [HideInInspector] public PlayerInput _agentInput;
    [HideInInspector] public Rigidbody2D rb2d;
    [HideInInspector] public AgentAnimation animationManager;
    [HideInInspector] public AgentRenderer _agentRenderer;
    [HideInInspector] public GroundDetector groundDetector;
    [HideInInspector] public ClimbingDetector climbingDetector;

    public AgentDataSO agentData;

    public State currentState;
    public State previousState;

    public State IdleState;

    [HideInInspector] public AgentWeaponManager agentWeapon;

    [Header("State Debugging:")]
    public string stateName;

    [SerializeField] UnityEvent OnRespawnRequired;

    private void Awake()
    {
        _agentInput = this.GetComponentInParent<PlayerInput>();
        rb2d = this.GetComponent<Rigidbody2D>();
        animationManager = this.GetComponentInChildren<AgentAnimation>();
        _agentRenderer = this.GetComponentInChildren<AgentRenderer>();
        groundDetector = this.GetComponentInChildren<GroundDetector>();
        climbingDetector = this.GetComponentInChildren<ClimbingDetector>();
        agentWeapon = this.GetComponentInChildren<AgentWeaponManager>();

        foreach (var state in this.GetComponentsInChildren<State>())
            state.InitializeState(this);
    }

    public void AgentDied()
    {
        OnRespawnRequired?.Invoke();
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
        groundDetector.CheckIsGrouded();
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
