using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Weapon
{
    using Projectile;
    using Target;

    public class ChargedPlasmaLauncherWeapon : Weapon
    {
        public const float arcLifetime = 0.5f;
        public const float initialWidth = 0.5f;
        public const float widthMultiplier = 0.9f;
        public const float minWidth = 0.01f;
        public const int branchTries = 3;

        

        public const float minSpreadDistance = 0.0f;
        public const float minSpreadDistanceMultiplier = 1.0f;

        public const float maxSpreadDistance = 40.0f;
        public const float maxSpreadDistanceMultiplier = 0.9f;

        public const float minSpreadAngle = 0.0f;
        public const float minSpreadAngleMultiplier = 1.0f;

        public const float maxSpreadAngle = 30.0f;
        public const float maxSpreadAngleMultiplier = 0.9f;

        public const float spreadChance = 5.0f;
        public const float spreadChanceMultiplier = 0.75f;



        public const float minBranchDistance = 0.0f;
        public const float minBranchDistanceMultiplier = 1.0f;

        public const float maxBranchDistance = 25.0f;
        public const float maxBranchDistanceMultiplier = 0.9f;

        public const float minBranchAngle = 30.0f;
        public const float minBranchAngleMultiplier = 1.0f;

        public const float maxBranchAngle = 60.0f;
        public const float maxBranchAngleMultiplier = 1.0f;

        public const float branchChance = 1.5f;
        public const float branchChanceMultiplier = 0.75f;

        public const int maxRecursion = 10;



        public new void Initialize
            (
            float baseDamage = 20.0f,
            float baseCritChance = 0.01f,
            float baseCritDamage = 100.0f,
            float baseKnockback = 0.0f,
            float baseAttackDelay = 10.0f,
            float baseProjectileSpeed = 100.0f,
            float baseProjectileSize = 1.0f,
            float baseProjectileLifetime = 2.0f,
            int basePiercing = 0,
            int baseArmorPenetration = int.MaxValue
            )
        {
            base.Initialize(baseDamage, baseCritChance, baseCritDamage, baseKnockback, baseAttackDelay, baseProjectileSpeed, baseProjectileSize, baseProjectileLifetime, basePiercing, baseArmorPenetration);
            prefab = Resources.Load<GameObject>("Prefabs/ChargedPlasmaProjectile");
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
                bulletObject.GetComponent<ChargedPlasmaProjectile>().Initialize(target, gameObject, damage, critChance, critDamage, knockback, projectileSpeed, projectileSize, projectileLifetime, armorPenetration, arcLifetime, initialWidth, widthMultiplier, minWidth, branchTries, minSpreadDistance, minSpreadDistanceMultiplier, maxSpreadDistance, maxSpreadDistanceMultiplier, minSpreadAngle, minSpreadAngleMultiplier, maxSpreadAngle, maxSpreadAngleMultiplier, spreadChance, spreadChanceMultiplier, minBranchDistance, minBranchDistanceMultiplier, maxBranchDistance, maxBranchDistanceMultiplier, minBranchAngle, minBranchAngleMultiplier, maxBranchAngle, maxBranchAngleMultiplier, branchChance, branchChanceMultiplier, maxRecursion);
                soundHandler.SoundShoot();

                attackTimer = attackDelay;
                hasCooledDown = false;
                return true;
            }
            return false;
        }
    } 
}
