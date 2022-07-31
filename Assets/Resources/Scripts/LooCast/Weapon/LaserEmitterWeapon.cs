using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.Projectile;
using System.Linq;

namespace LooCast.Weapon
{
    using Target;
    using Weapon.Data;

    public class LaserEmitterWeapon : Weapon
    {
        public float laserLength { get; private set; }

        public void Initialize(LaserEmitterWeaponData data)
        {
            base.Initialize(data);

            laserLength = data.LaserLength.Value;
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

                GameObject bulletObject = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                bulletObject.transform.position += new Vector3(0, 0, 0.1f);
                bulletObject.GetComponent<LaserProjectile>().Initialize(target, gameObject, damage, critChance, critDamage, knockback, projectileSpeed, projectileSize, baseProjectileLifetime, piercing, armorPenetration, laserLength);
                soundHandler.SoundShoot();

                attackTimer = attackDelay;
                hasCooledDown = false;
                return true;
            }
            return false;
        }
    } 
}
