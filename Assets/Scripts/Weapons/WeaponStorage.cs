using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace WeaponSystem
{
    public class WeaponStorage
    {
        private List<WeaponData> weaponDataList = new List<WeaponData>();
        private int currentWeaponIndex = -1;

        public int WeaponCount => weaponDataList.Count;

        internal WeaponData GetCurrentWeapon()
        {
            if (currentWeaponIndex == -1)
                return null;
            return weaponDataList[currentWeaponIndex];
        }

        internal WeaponData SwapWeapon()
        {
            if (currentWeaponIndex == -1) return null;
            currentWeaponIndex++;
            if (currentWeaponIndex >= WeaponCount)
                currentWeaponIndex = 0;
            return weaponDataList[currentWeaponIndex];
        }

        internal bool AddWeaponData(WeaponData weaponData)
        {
            if (weaponDataList.Contains(weaponData)) return false;

            weaponDataList.Add(weaponData);
            currentWeaponIndex = WeaponCount - 1;

            return true;
        }

        internal List<string> GetPlayerWeaponNames()
        {
            return weaponDataList.Select(weapon => weapon.name).ToList();
        }
    }
}
