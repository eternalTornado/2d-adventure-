using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementState : State
{
    [SerializeField] protected MovementData movementData;

    public State IdleState;

    public UnityEvent OnStep;

    private void Awake()
    {
        movementData = this.GetComponentInParent<MovementData>();
    }

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.Run);

        agent.animationManager.OnAnimationAction.AddListener(()=>OnStep.Invoke());

        movementData.horizontalMovementDirection = 0;
        movementData.currentSpeed = 0;
        movementData.currentVelocity = Vector2.zero;
    }

    protected override void ExitState()
    {
        agent.animationManager.ResetEvents();
    }

    public override void StateUpdate()
    {
        if (TestFalltransition())
            return;

        CalculateVelocity();
        SetPlayerVelocity();
        if (Mathf.Abs(agent.rb2d.velocity.x) < 0.01f)
            agent.TransitionToState(IdleState);
    }

    protected void SetPlayerVelocity()
    {
        agent.rb2d.velocity = movementData.currentVelocity;
    }

    protected void CalculateVelocity()
    {
        CalculateSpeed(agent._agentInput.movementVector, movementData);
        CalculateHorizontalDirection(movementData);
        movementData.currentVelocity = Vector3.right * movementData.horizontalMovementDirection * movementData.currentSpeed;
        movementData.currentVelocity.y = agent.rb2d.velocity.y;
    }

    protected void CalculateHorizontalDirection(MovementData movementData)
    {
        if (agent._agentInput.movementVector.x > 0)
            movementData.horizontalMovementDirection = 1;
        else if(agent._agentInput.movementVector.x < 0 )
            movementData.horizontalMovementDirection = -1;
    }

    protected void CalculateSpeed(Vector2 movementVector, MovementData movementData)
    {
        if (Mathf.Abs(movementVector.x) > 0)
            movementData.currentSpeed += agent.agentData.acceleration * Time.deltaTime;
        else
            movementData.currentSpeed -= agent.agentData.deacceleration * Time.deltaTime;

        movementData.currentSpeed = Mathf.Clamp(movementData.currentSpeed, 0f, agent.agentData.maxSpeed);
    }
}
