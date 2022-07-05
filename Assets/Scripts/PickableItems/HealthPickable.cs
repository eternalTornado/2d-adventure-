using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickable : Pickable
{
    [SerializeField] private int healthBoost = 1;
    public override void PickUp(Agent agent)
    {
        var damagable = agent.GetComponent<Damagable>();
        if (damagable == null)
            return;
        damagable.AddHealth(healthBoost);
    }
}
