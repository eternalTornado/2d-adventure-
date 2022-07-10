using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WeaponSystem;

public class Agent : MonoBehaviour
{
    [HideInInspector] public IAgentInput _agentInput;
    [HideInInspector] public Rigidbody2D rb2d;
    [HideInInspector] public AgentAnimation animationManager;
    [HideInInspector] public AgentRenderer _agentRenderer;

    [HideInInspector] public GroundDetector groundDetector;
    [HideInInspector] public ClimbingDetector climbingDetector;
    [HideInInspector] public StateFactory stateFactory;

    public AgentDataSO agentData;
    private Damagable damagable;

    public State currentState;
    public State previousState;

    [HideInInspector] public AgentWeaponManager agentWeapon;

    [Header("State Debugging:")]
    public string stateName;

    [SerializeField] UnityEvent OnRespawnRequired;
    public UnityEvent OnAgentDie;

    private void Awake()
    {
        _agentInput = this.GetComponentInParent<IAgentInput>();
        rb2d = this.GetComponent<Rigidbody2D>();
        animationManager = this.GetComponentInChildren<AgentAnimation>();
        _agentRenderer = this.GetComponentInChildren<AgentRenderer>();
        groundDetector = this.GetComponentInChildren<GroundDetector>();
        climbingDetector = this.GetComponentInChildren<ClimbingDetector>();
        agentWeapon = this.GetComponentInChildren<AgentWeaponManager>();
        stateFactory = this.GetComponentInChildren<StateFactory>();
        damagable = this.GetComponent<Damagable>();

        stateFactory.InitializeStates(this);
    }

    private void Start()
    {
        _agentInput.OnMovement += _agentRenderer.FaceDirection;

        InitializeAgent();

        _agentInput.OnWeaponChange += SwapWeapon;
    }

    private void SwapWeapon()
    {
        if (agentWeapon == null) return;

        agentWeapon.SwapWeapon();
    }

    private void InitializeAgent()
    {
        TransitionToState(stateFactory.GetState(StateType.Idle));
        damagable.Initialize(agentData.health);
    }

    public void AgentDied()
    {
        if (damagable.CurrentHealth > 0)
            OnRespawnRequired?.Invoke();
        else
            currentState?.Die();
    }

    public void GetHit()
    {
        currentState?.GetHit();
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

    public void PickUp(WeaponData weaponData)
    {
        if (agentWeapon == null) return;

        agentWeapon.PickUpWeapon(weaponData);
    }

    private void DisplayState()
    {
        stateName = currentState?.name ?? string.Empty;
    }
}
