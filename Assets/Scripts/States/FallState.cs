using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : MovementState
{
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
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Idle));
        else if(agent.climbingDetector.CanClimb && Mathf.Abs(agent._agentInput.movementVector.y) > 0)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Climbing));
        }
    }

    protected override void HandleOnJumpPressed()
    {
        // do nothing
    }
}
