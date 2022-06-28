using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    public float timeToWaitBeforeDieAction = 2f;

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.Die);
        agent.animationManager.OnAnimationEnd.AddListener(WaitBeforeDieAction);
    }

    protected override void ExitState()
    {
        StopAllCoroutines();
        agent.animationManager.ResetEvents();
        base.ExitState();
    } 

    protected override void HandleOnJumpPressed()
    {
        //Do nothing
    }

    public override void GetHit()
    {
        //Do nothing
    }

    protected override void HandleAttack()
    {
        //Do nothing
    }

    public override void StateUpdate()
    {
        //If died midair, only stops the horizontal movement
        agent.rb2d.velocity = new Vector2(0f, agent.rb2d.velocity.y);
    }

    public override void Die()
    {
        //Do nothing
    }

    private void WaitBeforeDieAction()
    {
        agent.animationManager.OnAnimationEnd.RemoveListener(WaitBeforeDieAction);
        StartCoroutine(WaitCoroutine());
    }
    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(timeToWaitBeforeDieAction);
        agent.OnAgentDie?.Invoke();
    }
}
