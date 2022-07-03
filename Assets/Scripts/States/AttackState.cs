using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackState : State
{
    public LayerMask hittableMask;

    protected Vector2 direction;

    public UnityEvent<AudioClip> OnWeaponSound;
    [SerializeField] private bool showGizmos = true;

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.Attack);
        agent.animationManager.ResetEvents();
        agent.animationManager.OnAnimationAction.AddListener(PerformAttack);
        agent.animationManager.OnAnimationEnd.AddListener(TransitionToIdleState);

        agent.agentWeapon.ToggleWeaponVisibility(true);
        direction = agent.transform.right * (agent.transform.localScale.x > 0 ? 1 : -1);
        if (agent.groundDetector.IsGrounded)
            agent.rb2d.velocity = Vector2.zero;
    }

    protected override void ExitState()
    {
        agent.agentWeapon.ToggleWeaponVisibility(false);
    }

    private void PerformAttack()
    {
        OnWeaponSound?.Invoke(agent.agentWeapon.GetCurrentWeapon().weaponSwingSound);
        agent.animationManager.OnAnimationAction.RemoveListener(PerformAttack);
        agent.agentWeapon.GetCurrentWeapon().PerformAttack(agent, hittableMask, direction);
    }

    private void TransitionToIdleState()
    {
        agent.animationManager.OnAnimationEnd.RemoveListener(TransitionToIdleState);
        if (agent.groundDetector.IsGrounded)
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Idle));
        else
            agent.TransitionToState(agent.stateFactory.GetState(StateType.Fall));
    }

    private void OnDrawGizmos()
    {
        //if (!Application.isPlaying) return;
        //if (!showGizmos) return;

        //Gizmos.color = Color.red;
        //agent.agentWeapon.GetCurrentWeapon().DrawWeaponGizmos(agent.transform.position, direction);
    }

    protected override void HandleAttack()
    {
        // Do nothing 
    }

    protected override void HandleOnJumpPressed()
    {
        // Do nothing
    }

    protected override void HandleOnJumpReleased()
    {
        
    }

    protected override void HandleOnMovement(Vector2 obj)
    {
        
    }

    public override void StateUpdate()
    {
        
    }

    public override void StateFixedUpdate()
    {
        
    }
}
