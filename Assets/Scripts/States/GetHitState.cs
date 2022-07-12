using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitState : State
{
    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.GetHit);
        agent.animationManager.OnAnimationEnd.AddListener(TransitionToIdle);
    }

    protected override void ExitState()
    {
        agent.animationManager.OnAnimationEnd.RemoveListener(TransitionToIdle);
    }

    private void TransitionToIdle()
    {
        agent.TransitionToState(agent.stateFactory.GetState(StateType.Idle));
    }

    protected override void HandleAttack()
    {
        //Do nothing
    }

    protected override void HandleOnJumpPressed()
    {
        //Do nothing
    }

    public override void StateUpdate()
    {
        //Do nothing
    }

    public override void GetHit()
    {
        //Do nothing
    }
}
