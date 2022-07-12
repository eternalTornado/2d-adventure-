using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShootBehaviour : AIBehaviour
{
    public AIPlayerDetector playerDetector;

    [SerializeField] private bool isWaiting;
    [SerializeField] private float delay = 1f;

    public override void PerformAction(AIEnemy enemyAI)
    {
        if (isWaiting) return;

        if (playerDetector.PlayerDetected)
        {
            isWaiting = true;
            enemyAI.CallOnMovement(playerDetector.DirectionToTarget);
            enemyAI.CallOnAttacke();
            StartCoroutine(AttackDelayCoroutine());
        }
    }

    private IEnumerator AttackDelayCoroutine()
    {
        yield return new WaitForSeconds(delay);
        isWaiting = false;
    }
}
