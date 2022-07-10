using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class ThrowableWeapon : MonoBehaviour
{
    Vector2 startPosition = Vector2.zero;
    RangeWeaponData data;
    Vector2 movementDirection;
    bool isInitialized = false;
    Rigidbody2D rb2d;

    public Transform spriteTransform;

    public float rotationSpeed = 1;

    [Header("Collision detection data")]
    [SerializeField] private Vector2 center = Vector2.zero;
    [SerializeField] [Range(0.1f, 2f)] private float radius = 1;
    [SerializeField] private Color gizmosColor = Color.red;
    [SerializeField] private LayerMask layerMask;

    private void Awake()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        if (spriteTransform == null)
            spriteTransform = transform.GetChild(0);
    }

    private void Start()
    {
        startPosition = transform.position;
    }

    public void Initialize(RangeWeaponData data, Vector2 direction, LayerMask layerMask)
    {
        this.movementDirection = direction;
        this.data = data;
        isInitialized = true;
        rb2d.velocity = movementDirection * data.weaponThrowSpeed;
        this.layerMask = layerMask;
    }

    private void Update()
    {
        if (isInitialized)
        {
            Fly();
            DetectCollision();
            if (((Vector2)this.transform.position - startPosition).magnitude >= data.attackRange)
                Destroy(this.gameObject);
        }
    }

    private void DetectCollision()
    {
        Collider2D collision = Physics2D.OverlapCircle((Vector2)this.transform.position + center,
            radius,
            layerMask.value);
        if(collision != null)
        {
            foreach (var hittable in collision.GetComponentsInChildren<IHittable>())
                hittable.GetHit(this.gameObject, data.weaponDamage);
            Destroy(this.gameObject);
        }
    }

    private void Fly()
    {
        this.transform.rotation *= Quaternion.Euler(0f, 0f, Time.deltaTime * rotationSpeed * -movementDirection.x);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;
        Gizmos.DrawSphere(transform.position + (Vector3)center, radius);
    }
}
