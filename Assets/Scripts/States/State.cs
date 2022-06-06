using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    protected Agent _agent;

    public UnityEvent OnEnter;
    public UnityEvent OnExit;

    public void InitializeState(Agent agent)
    {
        _agent = agent;
    }

    public void Enter()
    {
        _agent._agentInput.OnAttack += HandleAttack;
        _agent._agentInput.OnJumpPressed += HandleOnJumpPressed;
        _agent._agentInput.OnJumpReleased += HandleOnJumpReleased;
        _agent._agentInput.OnMovement += HandleOnMovement;

        OnEnter?.Invoke();
        EnterState();
    }

    public void Exit()
    {
        _agent._agentInput.OnAttack -= HandleAttack;
        _agent._agentInput.OnJumpPressed -= HandleOnJumpPressed;
        _agent._agentInput.OnJumpReleased -= HandleOnJumpReleased;
        _agent._agentInput.OnMovement -= HandleOnMovement;

        OnExit?.Invoke();
        ExitState();
    }

    protected virtual void EnterState()
    {

    }

    protected virtual void ExitState()
    {

    }

    protected virtual void HandleOnMovement(Vector2 obj)
    {

    }

    protected virtual void HandleOnJumpReleased()
    {

    }

    protected virtual void HandleOnJumpPressed()
    {

    }

    protected virtual void HandleAttack()
    {

    }

    public virtual void StateUpdate() { }
    public virtual void StateFixedUpdate() { }
}
