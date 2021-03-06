using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Weapon
{
    [CreateAssetMenu(fileName = "LaserEmitterWeaponData", menuName = "Data/Weapon/LaserEmitterWeaponData", order = 0)]
    public sealed class LaserEmitterWeaponData : WeaponData
    {
        public FloatReference LaserLength;
    } 
}
