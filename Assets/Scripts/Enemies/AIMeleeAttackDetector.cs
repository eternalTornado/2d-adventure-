using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIMeleeAttackDetector : MonoBehaviour
{
    public bool PlayerDetected { get; private set; }

    public LayerMask targetLayer;

    public UnityEvent<GameObject> OnPlayerDetected;

    [Range(0.1f, 1f)]
    public float radius;

    [Header("Gizmo parameters")]
    public Color gizmosColor = Color.green;
    public bool showGizmos = true;

    private void Update()
    {
        var collider = Physics2D.OverlapCircle(this.transform.position, radius, targetLayer);
        PlayerDetected = collider != null;
        if (collider != null)
            OnPlayerDetected?.Invoke(collider.gameObject);
    }

    private void OnDrawGizmos()
    {
        if (showGizmos)
        {
            Gizmos.color = gizmosColor;
            Gizmos.DrawSphere(this.transform.position, radius);
        }
    }
}
