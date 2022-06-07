using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace LooCast.Weapon
{
    using Target;
    using Projectile;
    using System;

    public class MultiplexerWeapon : Weapon
    {
        public int maxTargets { get; protected set; }
        public int maxFragments { get; protected set; }
        public int fragmentArmorPenetration { get; protected set; }
        public int tier { get; protected set; }

        public void Initialize
            (
            float baseDamage = 10.0f,
            float baseCritChance = 0.01f,
            float baseCritDamage = 75.0f,
            float baseKnockback = 1.0f,
            float baseAttackDelay = 2.5f,
            float baseProjectileSpeed = 50.0f,
            float baseProjectileSize = 1.0f,
            float baseProjectileLifetime = 3.0f,
            int basePiercing = 2,
            int baseArmorPenetration = 0,
            int maxTargets = 3,
            int maxFragments = 3,
            int fragmentArmorPenetration = 10,
            int tier = 0
            )
        {
            if (tier != 0)
            {
                switch (tier)
                {
                    case 1:
                        baseDamage = 10.0f;
                        baseCritChance = 0.01f;
                        baseCritDamage = 75.0f;
                        baseKnockback = 1.0f;
                        baseAttackDelay = 0.25f;
                        baseProjectileSpeed = 150.0f;
                        baseProjectileSize = 1.0f;
                        baseProjectileLifetime = 1.0f;
                        basePiercing = 2;
                        baseArmorPenetration = 0;
                        maxTargets = 1;
                        maxFragments = 0;
                        fragmentArmorPenetration = int.MaxValue;
                        break;
                    default:
                        throw new Exception("Tier does not exist!");
                } 
            }
            base.Initialize(baseDamage, baseCritChance, baseCritDamage, baseKnockback, baseAttackDelay, baseProjectileSpeed, baseProjectileSize, baseProjectileLifetime, basePiercing, baseArmorPenetration);
            this.maxTargets = maxTargets;
            this.maxFragments = maxFragments;
            this.fragmentArmorPenetration = fragmentArmorPenetration;
            this.tier = tier;

            prefab = Resources.Load<GameObject>("Prefabs/MultiplexerProjectile");
        }

        public override bool TryFire()
        {
            if (attackTimer <= 0.0f && hasCooledDown)
            {
                List<Target> targets = AcquireTargets(maxTargets, TargetingMode.Closest);
                if (targets == null || targets.Count == 0)
                {
                    return false;
                }

                foreach (Target target in targets)
                {
                    GameObject bulletObject = Instantiate(prefab, transform.position, Quaternion.identity);
                    bulletObject.transform.position += new Vector3(0, 0, 0.1f);
                    var finalFragments = maxFragments;
                    if (maxFragments >= 1)
                    {
                        finalFragments = new Random().Next(1, maxFragments);
                    }
                    bulletObject.GetComponent<MultiplexerProjectile>().Initialize(target, gameObject, damage, critChance, critDamage, knockback, projectileSpeed, projectileSize, projectileLifetime, piercing, armorPenetration, finalFragments, fragmentArmorPenetration, tier >= 1 ? true : false);
                }
                soundHandler.SoundShoot();

                attackTimer = attackDelay;
                hasCooledDown = false;
                return true;
            }
            return false;
        }
    } 
}
