using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementData : MonoBehaviour
{
    public int horizontalMovementDirection { get; set; }
    public float currentSpeed { get; set; }
    public Vector2 currentVelocity;
}
