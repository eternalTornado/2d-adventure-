using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public State MoveState;

    protected override void EnterState()
    {
        _agent._animationManager.PlayAnimation(AnimationType.Idle);
    }

    protected override void HandleOnMovement(Vector2 input)
    {
        if (Mathf.Abs(input.x) > 0.01f)
        {
            _agent.TransitionToState(MoveState);
        }
    }
}
