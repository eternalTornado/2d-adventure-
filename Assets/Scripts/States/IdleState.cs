using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public State MoveState;
    public State ClimbingState;

    protected override void EnterState()
    {
        _agent._animationManager.PlayAnimation(AnimationType.Idle);
        if (_agent._groundDetector.IsGrounded)
            _agent._rb2d.velocity = Vector2.zero;
    }

    protected override void HandleOnMovement(Vector2 input)
    {
        if(Mathf.Abs(input.y) > 0 && _agent.climbingDetector.CanClimb)
        {
            _agent.TransitionToState(ClimbingState);
        }
        if (Mathf.Abs(input.x) > 0.01f)
        {
            _agent.TransitionToState(MoveState);
        }
    }
}
