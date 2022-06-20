using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingState : State
{
    [SerializeField] State IdleState;
    private float prevGravityScale = 0f;

    protected override void EnterState()
    {
        prevGravityScale = _agent._rb2d.gravityScale;
        _agent._rb2d.gravityScale = 0f;
        _agent._rb2d.velocity = Vector2.zero;

        _agent._animationManager.PlayAnimation(AnimationType.Climb);
        _agent._animationManager.StopAnimation();
    }

    protected override void HandleOnJumpPressed()
    {
        _agent.TransitionToState(JumpState);
    }

    protected override void ExitState()
    {
        _agent._rb2d.gravityScale = prevGravityScale;

        _agent._animationManager.StartAnimation();
    }

    public override void StateUpdate()
    {
        if (_agent._agentInput.movementVector.magnitude > 0)
        {
            _agent._animationManager.StartAnimation();
            _agent._rb2d.velocity = new Vector2(_agent._agentInput.movementVector.x * _agent.agentData.climbHorizontalSpeed,
                _agent._agentInput.movementVector.y * _agent.agentData.climbVerticalSpeed);
        }
        else
        {
            _agent._rb2d.velocity = Vector2.zero;
            _agent._animationManager.StopAnimation();
        }

        if (!_agent.climbingDetector.CanClimb)
            _agent.TransitionToState(IdleState);    
    }
}
