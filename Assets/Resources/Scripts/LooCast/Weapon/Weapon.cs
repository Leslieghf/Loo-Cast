using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Weapon
{
    using Attribute.Stat;
    using Sound;
    using Util;
    using Target;

    [RequireComponent(typeof(Targeting))]
    public abstract class Weapon : ExtendedMonoBehaviour
    {
        protected Targeting targeting;
        protected GameObject prefab;
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

        [HideInInspector]
        public float attackTimer;
        public bool hasCooledDown { get; protected set; }

        public virtual void Initialize(float baseDamage, float baseCritChance, float baseCritDamage, float baseKnockback, float baseAttackDelay, float baseProjectileSpeed, float baseProjectileSize, float baseProjectileLifetime, int basePiercing, int baseArmorPenetration)
        {
            targeting = GetComponent<Targeting>();
            soundHandler = FindObjectOfType<GameSoundHandler>();

            this.baseDamage = baseDamage;
            this.baseCritChance = baseCritChance;
            this.baseCritDamage = baseCritDamage;
            this.baseKnockback = baseKnockback;
            this.baseAttackDelay = baseAttackDelay;
            this.baseProjectileSpeed = baseProjectileSpeed;
            this.baseProjectileSize = baseProjectileSize;
            this.projectileLifetime = baseProjectileLifetime;
            this.basePiercing = basePiercing;
            this.baseArmorPenetration = baseArmorPenetration;

            damage = baseDamage * Stats.damageMultiplier;
            critChance = baseCritChance * Stats.randomChanceMultiplier;
            critDamage = baseCritDamage * Stats.damageMultiplier;
            knockback = baseKnockback * Stats.knockbackMultiplier;
            attackDelay = baseAttackDelay * Stats.attackDelayMultiplier;
            projectileSpeed = baseProjectileSpeed * Stats.projectileSpeedMultiplier;
            projectileSize = baseProjectileSize * Stats.projectileSizeMultiplier;
            projectileLifetime = baseProjectileLifetime;
            piercing = basePiercing + Stats.piercingIncrease;
            armorPenetration = baseArmorPenetration + Stats.armorPenetrationIncrease;

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