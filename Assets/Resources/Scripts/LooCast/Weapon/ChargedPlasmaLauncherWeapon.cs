using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Weapon
{
    using Projectile;
    using Target;
    using Weapon.Data;

    public class ChargedPlasmaLauncherWeapon : Weapon
    {
        public float arcLifetime { get; private set; }
        public float arcInitialWidth { get; private set; }
        public float arcWidthMultiplier { get; private set; }
        public float arcMinWidth { get; private set; }
        public int arcBranchAttempts { get; private set; }
        public float minSpreadDistance { get; private set; }
        public float minSpreadDistanceMultiplier { get; private set; }
        public float maxSpreadDistance { get; private set; }
        public float maxSpreadDistanceMultiplier { get; private set; }
        public float minSpreadAngle { get; private set; }
        public float minSpreadAngleMultiplier { get; private set; }
        public float maxSpreadAngle { get; private set; }
        public float maxSpreadAngleMultiplier { get; private set; }
        public float spreadChance { get; private set; }
        public float spreadChanceMultiplier { get; private set; }
        public float minBranchDistance { get; private set; }
        public float minBranchDistanceMultiplier { get; private set; }
        public float maxBranchDistance { get; private set; }
        public float maxBranchDistanceMultiplier { get; private set; }
        public float minBranchAngle { get; private set; }
        public float minBranchAngleMultiplier { get; private set; }
        public float maxBranchAngle { get; private set; }
        public float maxBranchAngleMultiplier { get; private set; }
        public float branchChance { get; private set; }
        public float branchChanceMultiplier { get; private set; }
        public int maxRecursionDepth { get; private set; }

        public void Initialize(ChargedPlasmaLauncherWeaponData data)
        {
            base.Initialize(data);

            arcLifetime = data.ArcLifetime.Value;
            arcInitialWidth = data.ArcInitialWidth.Value;
            arcWidthMultiplier = data.ArcWidthMultiplier.Value;
            arcMinWidth = data.ArcMinWidth.Value;
            arcBranchAttempts = data.ArcBranchAttempts.Value;
            minSpreadDistance = data.MinSpreadDistance.Value;
            minSpreadDistanceMultiplier = data.MinSpreadDistanceMultiplier.Value;
            maxSpreadDistance = data.MaxSpreadDistance.Value;
            maxSpreadDistanceMultiplier = data.MaxSpreadDistanceMultiplier.Value;
            minSpreadAngle = data.MinSpreadAngle.Value;
            minSpreadAngleMultiplier = data.MinSpreadAngleMultiplier.Value;
            maxSpreadAngle = data.MaxSpreadAngle.Value;
            maxSpreadAngleMultiplier = data.MaxSpreadAngleMultiplier.Value;
            spreadChance = data.SpreadChance.Value;
            spreadChanceMultiplier = data.SpreadChanceMultiplier.Value;
            minBranchDistance = data.MinBranchDistance.Value;
            minBranchDistanceMultiplier = data.MinBranchDistanceMultiplier.Value;
            maxBranchDistance = data.MaxBranchDistance.Value;
            maxBranchDistanceMultiplier = data.MaxBranchDistanceMultiplier.Value;
            minBranchAngle = data.MinBranchAngle.Value;
            minBranchAngleMultiplier = data.MinBranchAngleMultiplier.Value;
            maxBranchAngle = data.MaxBranchAngle.Value;
            maxBranchAngleMultiplier = data.MaxBranchAngleMultiplier.Value;
            branchChance = data.BranchChance.Value;
            branchChanceMultiplier = data.BranchChanceMultiplier.Value;
            maxRecursionDepth = data.MaxRecursionDepth.Value;
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
                bulletObject.GetComponent<ChargedPlasmaProjectile>().Initialize(target, gameObject, damage, critChance, critDamage, knockback, projectileSpeed, projectileSize, baseProjectileLifetime, armorPenetration, arcLifetime, arcInitialWidth, arcWidthMultiplier, arcMinWidth, arcBranchAttempts, minSpreadDistance, minSpreadDistanceMultiplier, maxSpreadDistance, maxSpreadDistanceMultiplier, minSpreadAngle, minSpreadAngleMultiplier, maxSpreadAngle, maxSpreadAngleMultiplier, spreadChance, spreadChanceMultiplier, minBranchDistance, minBranchDistanceMultiplier, maxBranchDistance, maxBranchDistanceMultiplier, minBranchAngle, minBranchAngleMultiplier, maxBranchAngle, maxBranchAngleMultiplier, branchChance, branchChanceMultiplier, maxRecursionDepth);
                soundHandler.SoundShoot();

                attackTimer = attackDelay;
                hasCooledDown = false;
                return true;
            }
            return false;
        }
    } 
}
