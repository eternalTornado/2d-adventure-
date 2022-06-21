using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public State MoveState;
    public State ClimbingState;

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.Idle);
        if (agent.groundDetector.IsGrounded)
            agent.rb2d.velocity = Vector2.zero;
    }

    protected override void HandleOnMovement(Vector2 input)
    {
        if(Mathf.Abs(input.y) > 0 && agent.climbingDetector.CanClimb)
        {
            agent.TransitionToState(ClimbingState);
        }
        if (Mathf.Abs(input.x) > 0.01f)
        {
            agent.TransitionToState(MoveState);
        }
    }
}
