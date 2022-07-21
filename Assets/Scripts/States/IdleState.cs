using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.Idle);
        if (agent.groundDetector.IsGrounded)
            agent.rb2d.velocity = Vector2.zero;
    }

    public override void StateUpdate()
    {
        if (TestFalltransition()) return;

        if (Mathf.Abs(agent._agentInput.movementVector.y) > 0 && agent.climbingDetector.CanClimb)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Climbing));
        }
        if (Mathf.Abs(agent._agentInput.movementVector.x) > 0)
        {
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Move));
        }
    }

    //protected override void HandleOnMovement(Vector2 input)
    //{
    //    if(Mathf.Abs(input.y) > 0 && agent.climbingDetector.CanClimb)
    //    {
    //        agent.TransitionToState(agent.stateFactory.GetState(StateType.Climbing));
    //    }
    //    if (Mathf.Abs(input.x) > 0.01f)
    //    {
    //        agent.TransitionToState(agent.stateFactory.GetState(StateType.Move));
    //    }
    //}
}
