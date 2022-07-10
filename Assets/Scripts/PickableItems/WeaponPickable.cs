using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class WeaponPickable : Pickable
{
    [SerializeField] private WeaponData weaponData;

    private void Start()
    {
        spriteRenderer.sprite = weaponData.weaponSprite;
    }

    public override void PickUp(Agent agent)
    {
        agent.PickUp(weaponData);
    }
}
