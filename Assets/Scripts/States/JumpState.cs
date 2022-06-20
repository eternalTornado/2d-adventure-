using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : MovementState
{
    [SerializeField] State ClimbState;
    private bool jumpPressed;

    protected override void EnterState()
    {
        _agent._animationManager.PlayAnimation(AnimationType.Jump);
        movementData.currentVelocity = _agent._rb2d.velocity;
        movementData.currentVelocity.y = _agent.agentData.jumpForce;
        _agent._rb2d.velocity = movementData.currentVelocity;

        jumpPressed = true;
    }

    public override void StateUpdate()
    {
        ControlJumpHeight();
        CalculateVelocity();
        SetPlayerVelocity();

        if (_agent._rb2d.velocity.y <= 0)
            _agent.TransitionToState(FallState);
        else if(_agent.climbingDetector.CanClimb && Mathf.Abs(_agent._agentInput.movementVector.y) > 0)
        {
            _agent.TransitionToState(ClimbState);
        }
    }

    protected override void HandleOnJumpPressed()
    {
        jumpPressed = true;
    }

    protected override void HandleOnJumpReleased()
    {
        jumpPressed = false;
    }

    private void ControlJumpHeight()
    {
        if (!jumpPressed)
        {
            movementData.currentVelocity = _agent._rb2d.velocity;
            movementData.currentVelocity.y += _agent.agentData.lowJumpMultiplier * Physics2D.gravity.y * Time.deltaTime;
            _agent._rb2d.velocity = movementData.currentVelocity;
        }
    }
}
