using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimation : MonoBehaviour
{
    private Animator animator;

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
    Land
}
