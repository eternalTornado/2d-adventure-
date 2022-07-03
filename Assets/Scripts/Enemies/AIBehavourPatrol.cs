using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavourPatrol : AIBehaviour
{
    public AIEndPlatformDetector changeDirectionDirector;

    private Vector2 movementVector = Vector2.zero;

    private void Awake()
    {
        if (changeDirectionDirector == null)
            changeDirectionDirector = GetComponentInChildren<AIEndPlatformDetector>();
    }

    private void Start()
    {
        changeDirectionDirector.OnPathBlocked += HandlePathBlocked;
        movementVector = new Vector2(Random.Range(0, 1) > 0.5f ? 1 : -1, 0);
    }

    private void HandlePathBlocked()
    {
        movementVector *= Vector2.right * -1;
    }

    public override void PerformAction(AIEnemy enemyAI)
    {
        enemyAI.movementVector = movementVector;
        enemyAI.CallOnMovement(movementVector);
    }
}
