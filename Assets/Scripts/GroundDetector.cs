using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public Collider2D agentCollider;
    public LayerMask groundMask;

    public bool IsGrounded = false;

    public float boxCastOffsetX;
    public float boxCastOffsetY;
    public float boxCastWidth = 1;
    public float boxCastHeight = 1;
    public Color gizmosColorIsGrounded = Color.green;
    public Color gizmosColorNotGrounded = Color.red;

    private void Awake()
    {
        if (agentCollider == null)
            agentCollider = this.GetComponent<Collider2D>();
    }

    public void CheckIsGrouded()
    {
        var raycastHit = Physics2D.BoxCast(agentCollider.bounds.center + new Vector3(boxCastOffsetX, boxCastOffsetY),
            new Vector3(boxCastWidth, boxCastHeight),
            0,
            Vector3.down,
            0,
            groundMask);

        if(raycastHit.collider != null)
        {
            if(raycastHit.collider.IsTouching(agentCollider))
                IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (agentCollider == null) return;

        Gizmos.color = IsGrounded ? gizmosColorIsGrounded : gizmosColorNotGrounded;
        Gizmos.DrawWireCube(agentCollider.bounds.center + new Vector3(boxCastOffsetX, boxCastOffsetY, 0),
            new Vector3(boxCastWidth, boxCastHeight));
    }
}
