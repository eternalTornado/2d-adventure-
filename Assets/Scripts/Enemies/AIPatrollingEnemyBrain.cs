using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrollingEnemyBrain : AIEnemy
{
    public GroundDetector agentGroundDetector;

    public AIBehaviour attackBehaviour, patrolBehaviour;

    private void Awake()
    {
        if (agentGroundDetector == null)
            agentGroundDetector = this.GetComponentInChildren<GroundDetector>();
    }

    private void Update()
    {
        if (agentGroundDetector.IsGrounded)
        {
            attackBehaviour.PerformAction(this);
            patrolBehaviour.PerformAction(this);
        }
    }
}
