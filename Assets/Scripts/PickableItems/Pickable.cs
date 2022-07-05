using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickable : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;

    [SerializeField] private BoxCollider2D pickableCollider;

    [SerializeField] protected Color gizmoColor = Color.magenta;

    private void Awake()
    {
        spriteRenderer = this.GetComponentInChildren<SpriteRenderer>();
        pickableCollider = this.GetComponent<BoxCollider2D>();
    }

    public abstract void PickUp(Agent agent);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUp(collision.GetComponent<Agent>());
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawCube(pickableCollider.bounds.center, pickableCollider.bounds.size);
    }
}
