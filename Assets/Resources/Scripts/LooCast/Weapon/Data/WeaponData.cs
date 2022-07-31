using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Weapon.Data
{
    public abstract class WeaponData : ScriptableObject
    {
        public FloatReference BaseDamage;
        public FloatReference BaseCritChance;
        public FloatReference BaseCritDamage;
        public FloatReference BaseKnockback;
        public FloatReference BaseAttackDelay;
        public FloatReference BaseProjectileSpeed;
        public FloatReference BaseProjectileSize;
        public FloatReference BaseProjectileLifetime;
        public IntReference BasePiercing;
        public IntReference BaseArmorPenetration;
        public StringReference ProjectilePrefabResourcePath;
    } 
}
