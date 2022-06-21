using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : MovementState
{
    [SerializeField] State ClimbState;

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.Fall);

    }

    public override void StateUpdate()
    {
        movementData.currentVelocity = agent.rb2d.velocity;
        movementData.currentVelocity.y += agent.agentData.gravityModifier * Physics2D.gravity.y * Time.deltaTime;
        agent.rb2d.velocity = movementData.currentVelocity;

        CalculateVelocity();
        SetPlayerVelocity();

        if (agent.groundDetector.IsGrounded)
            agent.TransitionToState(IdleState);
        else if(agent.climbingDetector.CanClimb && Mathf.Abs(agent._agentInput.movementVector.y) > 0)
        {
            agent.TransitionToState(ClimbState);
        }
    }

    protected override void HandleOnJumpPressed()
    {
        // do nothing
    }
}
