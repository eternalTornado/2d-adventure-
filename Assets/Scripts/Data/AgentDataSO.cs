using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AgentData", menuName = "Agent/Data")]
public class AgentDataSO : ScriptableObject
{
    public int health = 5;

    [Header("Movement Data")]
    public float maxSpeed = 6f;
    public float acceleration = 50f;
    public float deacceleration = 50f;

    [Header("Jump data")]
    public float jumpForce = 12f;
    public float lowJumpMultiplier = 2f;
    public float gravityModifier = 0.5f;

    [Header("Climb data")]
    public float climbHorizontalSpeed = 2f;
    public float climbVerticalSpeed = 5f;
}
