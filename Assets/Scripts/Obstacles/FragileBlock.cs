using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WeaponSystem;

public class FragileBlock : MonoBehaviour, IHittable
{
    public UnityEvent OnHit;

    private Animator animator;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    public void GetHit(GameObject gameObject, int weaponDamage)
    {
        OnHit?.Invoke();

        animator.Play("FragileBlockDestroy");
    }

    public void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
