using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Util;
using LooCast.AOE;
using LooCast.Target;
using LooCast.Sound;
using LooCast.Attribute.Stat;

namespace LooCast.Weapon
{
    using Target;

    public class FreezeRayWeapon : Weapon
    {
        public new void Initialize
            (
            float baseDamage = 0.0f,
            float baseCritChance = 0.0f,
            float baseCritDamage = 0.0f,
            float baseKnockback = 0.0f,
            float baseAttackDelay = 20.0f,
            float baseProjectileSpeed = 100.0f,
            float baseProjectileSize = 1.0f,
            float baseProjectileLifetime = 5.0f,
            int basePiercing = 0,
            int baseArmorPenetration = 0
            )
        {
            base.Initialize(baseDamage, baseCritChance, baseCritDamage, baseKnockback, baseAttackDelay, baseProjectileSpeed, baseProjectileSize, baseProjectileLifetime, basePiercing, baseArmorPenetration);

            prefab = Resources.Load<GameObject>("Prefabs/FreezeZone");
        }

        public override bool TryFire()
        {
            if (attackTimer <= 0.0f && hasCooledDown)
            {
                List<Target> targets = AcquireTargets(1, TargetingMode.Closest);
                if (targets == null || targets.Count == 0)
                {
                    return false;
                }
                Target target = targets[0];

                var freezeOrbObject = Instantiate(prefab, transform.position, Quaternion.identity);
                freezeOrbObject.transform.position += new Vector3(0, 0, 0.1f);
                var freezeSpeedMultiplier = 0.5f;
                var freezeRadiusMultiplier = projectileSize;
                var freezeLifetime = projectileLifetime;
                freezeOrbObject.GetComponent<FreezeZone>().Initialize(target.transform.position, freezeSpeedMultiplier, freezeRadiusMultiplier, freezeLifetime);
                soundHandler.SoundShoot();

                attackTimer = attackDelay;
                hasCooledDown = false;
                return true;
            }
            return false;
        }
    } 
}
