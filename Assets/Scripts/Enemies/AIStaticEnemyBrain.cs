using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStaticEnemyBrain : AIEnemy
{
    public AIBehaviour attackBehaviour;

    private void Update()
    {
        attackBehaviour.PerformAction(this);
    }
}
