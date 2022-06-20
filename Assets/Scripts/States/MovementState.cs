using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : State
{
    [SerializeField] protected MovementData movementData;

    public State IdleState;

    private void Awake()
    {
        movementData = this.GetComponentInParent<MovementData>();
    }

    protected override void EnterState()
    {
        _agent._animationManager.PlayAnimation(AnimationType.Run);

        movementData.horizontalMovementDirection = 0;
        movementData.currentSpeed = 0;
        movementData.currentVelocity = Vector2.zero;
    }

    public override void StateUpdate()
    {
        if (TestFalltransition())
            return;

        CalculateVelocity();
        SetPlayerVelocity();
        if (Mathf.Abs(_agent._rb2d.velocity.x) < 0.01f)
            _agent.TransitionToState(IdleState);
    }

    protected void SetPlayerVelocity()
    {
        _agent._rb2d.velocity = movementData.currentVelocity;
    }

    protected void CalculateVelocity()
    {
        CalculateSpeed(_agent._agentInput.movementVector, movementData);
        CalculateHorizontalDirection(movementData);
        movementData.currentVelocity = Vector3.right * movementData.horizontalMovementDirection * movementData.currentSpeed;
        movementData.currentVelocity.y = _agent._rb2d.velocity.y;
    }

    protected void CalculateHorizontalDirection(MovementData movementData)
    {
        if (_agent._agentInput.movementVector.x > 0)
            movementData.horizontalMovementDirection = 1;
        else if(_agent._agentInput.movementVector.x < 0 )
            movementData.horizontalMovementDirection = -1;
    }

    protected void CalculateSpeed(Vector2 movementVector, MovementData movementData)
    {
        if (Mathf.Abs(movementVector.x) > 0)
            movementData.currentSpeed += _agent.agentData.acceleration * Time.deltaTime;
        else
            movementData.currentSpeed -= _agent.agentData.deacceleration * Time.deltaTime;

        movementData.currentSpeed = Mathf.Clamp(movementData.currentSpeed, 0f, _agent.agentData.maxSpeed);
    }
}
