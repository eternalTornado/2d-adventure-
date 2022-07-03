using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class HittableKnockback : MonoBehaviour, IHittable
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float force;

    private void Awake()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    public void GetHit(GameObject gameObject, int weaponDamage)
    {
        var direction = this.transform.position - gameObject.transform.position;
        rb2d.AddForce(new Vector2(direction.normalized.x, 0) * force, ForceMode2D.Impulse);
    }
}
