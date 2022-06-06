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
}
