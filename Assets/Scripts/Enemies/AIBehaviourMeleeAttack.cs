using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviourMeleeAttack : AIBehaviour
{
    public AIMeleeAttackDetector meleeRangeDetector;

    [SerializeField] private bool isWaiting;
    [SerializeField] private float delay = 0.1f;

    private void Awake()
    {
        if (meleeRangeDetector == null)
            meleeRangeDetector = this.transform.parent.GetComponentInChildren<AIMeleeAttackDetector>();
    }

    public override void PerformAction(AIEnemy enemyAI)
    {
        if (isWaiting)
            return;

        if (!meleeRangeDetector.PlayerDetected)
            return;

        enemyAI.CallOnAttacke();
        isWaiting = true;
        StartCoroutine(AttackDelayCoroutine());
    }

    private IEnumerator AttackDelayCoroutine()
    {
        yield return new WaitForSeconds(delay);

        isWaiting = false;
    }
}
