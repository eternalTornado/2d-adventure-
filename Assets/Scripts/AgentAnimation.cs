using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentAnimation : MonoBehaviour
{
    private Animator animator;

    public UnityEvent OnAnimationAction;
    public UnityEvent OnAnimationEnd;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    public void PlayAnimation(AnimationType type)
    {
        Play(type.ToString());
    }

    private void Play(string animName)
    {
        animator.Play(animName, -1, 0);
    }

    internal void StopAnimation()
    {
        animator.enabled = false;
    }

    internal void StartAnimation()
    {
        animator.enabled = true;
    }

    public void ResetEvents()
    {
        OnAnimationAction.RemoveAllListeners();
        OnAnimationEnd.RemoveAllListeners();
    }

    public void InvokeAnimationAction()
    {
        OnAnimationAction?.Invoke();
    }

    public void InvokeAnimationEnd()
    {
        OnAnimationEnd?.Invoke();
    }
}

public enum AnimationType
{
    Die,
    Hit,
    Idle, 
    Attack,
    Run,
    Jump,
    Fall,
    Climb,
    Land,
    GetHit
}
