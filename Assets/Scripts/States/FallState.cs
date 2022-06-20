using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : MovementState
{
    [SerializeField] State ClimbState;

    protected override void EnterState()
    {
        _agent._animationManager.PlayAnimation(AnimationType.Fall);

    }

    public override void StateUpdate()
    {
        movementData.currentVelocity = _agent._rb2d.velocity;
        movementData.currentVelocity.y += _agent.agentData.gravityModifier * Physics2D.gravity.y * Time.deltaTime;
        _agent._rb2d.velocity = movementData.currentVelocity;

        CalculateVelocity();
        SetPlayerVelocity();

        if (_agent._groundDetector.IsGrounded)
            _agent.TransitionToState(IdleState);
        else if(_agent.climbingDetector.CanClimb && Mathf.Abs(_agent._agentInput.movementVector.y) > 0)
        {
            _agent.TransitionToState(ClimbState);
        }
    }

    protected override void HandleOnJumpPressed()
    {
        // do nothing
    }
}
