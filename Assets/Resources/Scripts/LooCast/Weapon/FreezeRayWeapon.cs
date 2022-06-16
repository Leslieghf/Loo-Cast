using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LooCast.AOE;

namespace LooCast.Weapon
{
    using Target;
    using Data.Weapon;

    public class FreezeRayWeapon : Weapon
    {
        public void Initialize(FreezeRayWeaponData data)
        {
            base.Initialize(data);
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

                var freezeOrbObject = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                freezeOrbObject.transform.position += new Vector3(0, 0, 0.1f);
                var freezeSpeedMultiplier = 0.5f;
                var freezeRadiusMultiplier = projectileSize;
                var freezeLifetime = baseProjectileLifetime;
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
