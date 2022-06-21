using UnityEngine;

namespace WeaponSystem
{
    public interface IHittable
    {
        public void GetHit(GameObject gameObject, int weaponDamage);
    }
}
