using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "New melee weapon data", menuName = "Weapons/MeleeWeaponData")]
    public class MeleeWeaponData : WeaponData
    {
        public float attackRange = 2f;

        public override bool CanBeUsed(bool isGrounded)
        {
            return isGrounded;
        }

        public override void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction)
        {
            Debug.LogError("Weapon used: " + weaponName);
            RaycastHit2D hit = Physics2D.Raycast(agent.agentWeapon.transform.position, direction, attackRange, hittableMask);
            if(hit.collider != null)
            {
                foreach(var hittable in hit.collider.GetComponents<IHittable>())
                {
                    hittable.GetHit(agent.gameObject, weaponDamage);
                }
            }
        }

        public override void DrawWeaponGizmos(Vector3 origin, Vector3 direction)
        {
            Debug.LogError("Weapon used: " + weaponName);
            Gizmos.DrawLine(origin, origin + direction * attackRange);
        }
    }
}
