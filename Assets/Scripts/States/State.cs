using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    protected Agent agent;

    public UnityEvent OnEnter;
    public UnityEvent OnExit;

    public void InitializeState(Agent agent)
    {
        this.agent = agent;
    }

    public void Enter()
    {
        agent._agentInput.OnAttack += HandleAttack;
        agent._agentInput.OnJumpPressed += HandleOnJumpPressed;
        agent._agentInput.OnJumpReleased += HandleOnJumpReleased;
        agent._agentInput.OnMovement += HandleOnMovement;

        OnEnter?.Invoke();
        EnterState();
    }

    public void Exit()
    {
        agent._agentInput.OnAttack -= HandleAttack;
        agent._agentInput.OnJumpPressed -= HandleOnJumpPressed;
        agent._agentInput.OnJumpReleased -= HandleOnJumpReleased;
        agent._agentInput.OnMovement -= HandleOnMovement;

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
        TestJumpState();
    }

    private void TestJumpState()
    {
        if (agent.groundDetector.IsGrounded)
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Jump));
    }

    protected virtual void HandleAttack()
    {
        TestAttackTransition();
    }

    public virtual void StateUpdate()
    {
        TestFalltransition();
    }

    public virtual void GetHit()
    {
        agent.TransitionToState(agent.stateFactory.GetState(StateType.GetHit));
    }

    protected bool TestFalltransition()
    {
        if (!agent.groundDetector.IsGrounded)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Fall));
            return true;
        }

        return false;
    }

    public virtual void StateFixedUpdate() { }

    public virtual void Die()
    {
        agent.TransitionToState(agent.stateFactory.GetState(StateType.Die));
    }

    protected virtual void TestAttackTransition()
    {
        if (agent.agentWeapon.CanIUseWeapon(agent.groundDetector.IsGrounded))
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Attack)); 
        }
    }
}
