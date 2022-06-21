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
        agent.animationManager.PlayAnimation(AnimationType.Jump);
        movementData.currentVelocity = agent.rb2d.velocity;
        movementData.currentVelocity.y = agent.agentData.jumpForce;
        agent.rb2d.velocity = movementData.currentVelocity;

        jumpPressed = true;
    }

    public override void StateUpdate()
    {
        ControlJumpHeight();
        CalculateVelocity();
        SetPlayerVelocity();

        if (agent.rb2d.velocity.y <= 0)
            agent.TransitionToState(FallState);
        else if(agent.climbingDetector.CanClimb && Mathf.Abs(agent._agentInput.movementVector.y) > 0)
        {
            agent.TransitionToState(ClimbState);
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
            movementData.currentVelocity = agent.rb2d.velocity;
            movementData.currentVelocity.y += agent.agentData.lowJumpMultiplier * Physics2D.gravity.y * Time.deltaTime;
            agent.rb2d.velocity = movementData.currentVelocity;
        }
    }
}
