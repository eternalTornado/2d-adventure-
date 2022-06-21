using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public abstract class WeaponData : ScriptableObject, IEquatable<WeaponData>
    {
        public string weaponName;
        public Sprite weaponSprite;
        public int weaponDamage;
        public AudioClip weaponSwingSound;

        public bool Equals(WeaponData other)
        {
            return weaponName == other.weaponName;
        }

        public abstract bool CanBeUsed(bool isGrounded);
        public abstract void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction);

        public virtual void DrawWeaponGizmos(Vector3 origin, Vector3 direction)
        {

        }
    }
}
