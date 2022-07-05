using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRb2DMovementUtil : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    public void StopMovement()
    {
        rb2d.velocity = Vector2.zero;
    }
}
