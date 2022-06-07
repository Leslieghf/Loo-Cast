using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Projectile;
using System.Linq;

namespace LooCast.Weapon
{
    using Target;

    public class LaserEmitterWeapon : Weapon
    {
        public float laserLength { get; protected set; }

        public new void Initialize
            (
            float baseDamage = 15.0f,
            float baseCritChance = 0.01f,
            float baseCritDamage = 75.0f,
            float baseKnockback = 0.0f,
            float baseAttackDelay = 5.0f,
            float baseProjectileSpeed = 150.0f,
            float baseProjectileSize = 1.0f,
            float baseProjectileLifetime = 1.0f,
            int basePiercing = 0,
            int baseArmorPenetration = 10
            )
        {
            base.Initialize(baseDamage, baseCritChance, baseCritDamage, baseKnockback, baseAttackDelay, baseProjectileSpeed, baseProjectileSize, baseProjectileLifetime, basePiercing, baseArmorPenetration);
            laserLength = 5.0f;
            prefab = Resources.Load<GameObject>("Prefabs/LaserProjectile");
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

                GameObject bulletObject = Instantiate(prefab, transform.position, Quaternion.identity);
                bulletObject.transform.position += new Vector3(0, 0, 0.1f);
                bulletObject.GetComponent<LaserProjectile>().Initialize(target, gameObject, damage, critChance, critDamage, knockback, projectileSpeed, projectileSize, projectileLifetime, piercing, armorPenetration, laserLength);
                soundHandler.SoundShoot();

                attackTimer = attackDelay;
                hasCooledDown = false;
                return true;
            }
            return false;
        }
    } 
}
