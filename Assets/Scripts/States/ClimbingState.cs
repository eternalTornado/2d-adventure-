using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingState : State
{
    [SerializeField] State IdleState;
    private float prevGravityScale = 0f;

    protected override void EnterState()
    {
        prevGravityScale = agent.rb2d.gravityScale;
        agent.rb2d.gravityScale = 0f;
        agent.rb2d.velocity = Vector2.zero;

        agent.animationManager.PlayAnimation(AnimationType.Climb);
        agent.animationManager.StopAnimation();
    }

    protected override void HandleOnJumpPressed()
    {
        agent.TransitionToState(JumpState);
    }

    protected override void ExitState()
    {
        agent.rb2d.gravityScale = prevGravityScale;

        agent.animationManager.StartAnimation();
    }

    protected override void HandleAttack()
    {
        
    }

    public override void StateUpdate()
    {
        if (agent._agentInput.movementVector.magnitude > 0)
        {
            agent.animationManager.StartAnimation();
            agent.rb2d.velocity = new Vector2(agent._agentInput.movementVector.x * agent.agentData.climbHorizontalSpeed,
                agent._agentInput.movementVector.y * agent.agentData.climbVerticalSpeed);
        }
        else
        {
            agent.rb2d.velocity = Vector2.zero;
            agent.animationManager.StopAnimation();
        }

        if (!agent.climbingDetector.CanClimb)
            agent.TransitionToState(IdleState);    
    }
}
