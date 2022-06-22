using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Weapon
{
    using Attribute.Stat;
    using Sound;
    using Util;
    using Target;
    using Data.Weapon;

    [RequireComponent(typeof(Targeting))]
    public abstract class Weapon : ExtendedMonoBehaviour
    {
        protected Targeting targeting;
        protected GameSoundHandler soundHandler;

        public float baseDamage { get; protected set; }
        public float baseCritChance { get; protected set; }
        public float baseCritDamage { get; protected set; }
        public float baseKnockback { get; protected set; }
        public float baseAttackDelay { get; protected set; }
        public float baseProjectileSpeed { get; protected set; }
        public float baseProjectileSize { get; protected set; }
        public float baseProjectileLifetime { get; protected set; }
        public int basePiercing { get; protected set; }
        public int baseArmorPenetration { get; protected set; }

        public float damage { get; protected set; }
        public float critChance { get; protected set; }
        public float critDamage { get; protected set; }
        public float knockback { get; protected set; }
        public float attackDelay { get; protected set; }
        public float projectileSpeed { get; protected set; }
        public float projectileSize { get; protected set; }
        public float projectileLifetime { get; protected set; }
        public int piercing { get; protected set; }
        public int armorPenetration { get; protected set; }
        public string projectilePrefabResourcePath { get; protected set; }
        public GameObject projectilePrefab { get; protected set; }

        [HideInInspector]
        public float attackTimer;
        public bool hasCooledDown { get; protected set; }

        public void Initialize(WeaponData data)
        {
            targeting = GetComponent<Targeting>();
            soundHandler = FindObjectOfType<GameSoundHandler>();

            baseDamage = data.BaseDamage.Value;
            baseCritChance = data.BaseCritChance.Value;
            baseCritDamage = data.BaseCritDamage.Value;
            baseKnockback = data.BaseKnockback.Value;
            baseAttackDelay = data.BaseAttackDelay.Value;
            baseProjectileSpeed = data.BaseProjectileSpeed.Value;
            baseProjectileSize = data.BaseProjectileSize.Value;
            baseProjectileLifetime = data.BaseProjectileLifetime.Value;
            basePiercing = data.BasePiercing.Value;
            baseArmorPenetration = data.BaseArmorPenetration.Value;
            projectilePrefabResourcePath = data.ProjectilePrefabResourcePath.Value;
            projectilePrefab = Resources.Load<GameObject>(projectilePrefabResourcePath);


            damage = baseDamage * Stats.DamageMultiplier;
            critChance = baseCritChance * Stats.RandomChanceMultiplier;
            critDamage = baseCritDamage * Stats.DamageMultiplier;
            knockback = baseKnockback * Stats.KnockbackMultiplier;
            attackDelay = baseAttackDelay * Stats.AttackDelayMultiplier;
            projectileSpeed = baseProjectileSpeed * Stats.ProjectileSpeedMultiplier;
            projectileSize = baseProjectileSize * Stats.ProjectileSizeMultiplier;
            projectileLifetime = baseProjectileLifetime;
            piercing = basePiercing + Stats.PiercingIncrease;
            armorPenetration = baseArmorPenetration + Stats.ArmorPenetrationIncrease;

            attackTimer = 0.0f;
            hasCooledDown = false;
        }

        protected override void Cycle()
        {
            if (attackTimer <= 0.0f)
            {
                if (!hasCooledDown)
                {
                    hasCooledDown = true;
                }
                TryFire();
            }
            else if (attackTimer > 0.0f && !hasCooledDown)
            {
                attackTimer -= Time.deltaTime;
            }
        }

        public abstract bool TryFire();

        protected virtual List<Target> AcquireTargets(int count, TargetingMode targetType)
        {
            List<Target> targetsFound;

            switch (targetType)
            {
                case TargetingMode.Closest:
                    targetsFound = targeting.closestTargets;
                    break;
                case TargetingMode.Furthest:
                    targetsFound = targeting.furthestTargets;
                    break;
                case TargetingMode.Random:
                    targetsFound = targeting.randomTargets;
                    break;
                case TargetingMode.RandomOnscreen:
                    targetsFound = targeting.randomOnscreenTargets;
                    break;
                case TargetingMode.RandomProximity:
                    targetsFound = targeting.randomProximityTargets;
                    break;
                default:
                    targetsFound = null;
                    break;
            }

            if (targetsFound == null)
            {
                return null;
            }

            List<Target> targets = new List<Target>();

            foreach (Target target in targetsFound)
            {
                if (targets.Count >= count)
                {
                    break;
                }

                if (target == null || !target.IsValid() || target.IsLocked())
                {
                    continue;
                }

                Target.EngageTargetLock(target, out bool targetLockSuccess);

                if (targetLockSuccess)
                {
                    targets.Add(target);
                }
                else
                {
                    continue;
                }
            }

            return targets;
        }
    } 
}
