using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Projectile
{
    using Health;
    using Target;
    using Arc;
    using Random;

    public class ChargedPlasmaProjectile : Projectile
    {
        public List<Arc> arcs { get; protected set; }
        protected List<Target> ignoredTargets;
        public Gradient arcGradient;


        protected float arcLifetime;
        protected float initialWidth;
        protected float widthMultiplier;
        protected float minWidth;
        protected int branchTries;



        protected float minSpreadDistance;
        protected float minSpreadDistanceMultiplier;

        protected float maxSpreadDistance;
        protected float maxSpreadDistanceMultiplier;

        protected float minSpreadAngle;
        protected float minSpreadAngleMultiplier;

        protected float maxSpreadAngle;
        protected float maxSpreadAngleMultiplier;

        protected float spreadChance;
        protected float spreadChanceMultiplier;



        protected float minBranchDistance;
        protected float minBranchDistanceMultiplier;

        protected float maxBranchDistance;
        protected float maxBranchDistanceMultiplier;

        protected float minBranchAngle;
        protected float minBranchAngleMultiplier;

        protected float maxBranchAngle;
        protected float maxBranchAngleMultiplier;

        protected float branchChance;
        protected float branchChanceMultiplier;

        protected int maxRecursion;



        public virtual void Initialize(Target target, GameObject origin, float damage, float critChance, float critDamage, float knockback, float speed, float size, float lifetime, int armorPenetration, float arcLifetime, float initialWidth, float widthMultiplier, float minWidth, int branchTries, float minSpreadDistance, float minSpreadDistanceMultiplier, float maxSpreadDistance, float maxSpreadDistanceMultiplier, float minSpreadAngle, float minSpreadAngleMultiplier, float maxSpreadAngle, float maxSpreadAngleMultiplier, float spreadChance, float spreadChanceMultiplier, float minBranchDistance, float minBranchDistanceMultiplier, float maxBranchDistance, float maxBranchDistanceMultiplier, float minBranchAngle, float minBranchAngleMultiplier, float maxBranchAngle, float maxBranchAngleMultiplier, float branchChance, float branchChanceMultiplier, int maxRecursion)
        {
            base.Initialize(target, origin, damage, critChance, critDamage, knockback, speed, size, lifetime, 0, armorPenetration);

            arcs = new List<Arc>();
            ignoredTargets = new List<Target>();

            if (target == null || target.transform == null)
            {
                float x = Random.Range(-1f, 1f);
                float y = Random.Range(-1f, 1f);
                Vector3 direction = new Vector3(x, y, 0f).normalized;
                rb.velocity = direction;
            }
            else
            {
                float projectileArrivalTime = (target.transform.position - origin.transform.position).magnitude / speed;
                Vector3 targetVelocity = target.gameObject.GetComponent<Rigidbody2D>().velocity;
                targetVelocity.z = 0;
                Vector3 estimatedProjectileHitPos = target.transform.position + targetVelocity * projectileArrivalTime;

                rb.velocity = (estimatedProjectileHitPos - transform.position).normalized;
            }
            rb.velocity *= speed;

            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg - 90.0f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            this.arcLifetime = arcLifetime;
            this.initialWidth = initialWidth;
            this.widthMultiplier = widthMultiplier;
            this.minWidth = minWidth;
            this.branchTries = branchTries;

            this.minSpreadDistance = minSpreadDistance;
            this.minSpreadDistanceMultiplier = minSpreadDistanceMultiplier;

            this.maxSpreadDistance = maxSpreadDistance;
            this.maxSpreadDistanceMultiplier = maxSpreadDistanceMultiplier;

            this.minSpreadAngle = minSpreadAngle;
            this.minSpreadAngleMultiplier = minSpreadAngleMultiplier;

            this.maxSpreadAngle = maxSpreadAngle;
            this.maxSpreadAngleMultiplier = maxSpreadAngleMultiplier;

            this.spreadChance = spreadChance;
            this.spreadChanceMultiplier = spreadChanceMultiplier;


            this.minBranchDistance = minBranchDistance;
            this.minBranchDistanceMultiplier = minBranchDistanceMultiplier;

            this.maxBranchDistance = maxBranchDistance;
            this.maxBranchDistanceMultiplier = maxBranchDistanceMultiplier;

            this.minBranchAngle = minBranchAngle;
            this.minBranchAngleMultiplier = minBranchAngleMultiplier;

            this.maxBranchAngle = maxBranchAngle;
            this.maxBranchAngleMultiplier = maxBranchAngleMultiplier;

            this.branchChance = branchChance;
            this.branchChanceMultiplier = branchChanceMultiplier;

            this.maxRecursion = maxRecursion;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            bool CheckTags(params string[] tags)
            {
                foreach (string tag in tags)
                {
                    if (collision.gameObject.CompareTag(tag))
                    {
                        return true;
                    }
                }
                return false;
            }

            if (CheckTags("Enemy", "EnemyStation"))
            {
                GameObject arcObject = new GameObject();
                arcObject.name = "Arc";
                arcObject.transform.position = collision.transform.position;
                Arc arc = arcObject.AddComponent<Arc>();
                Target collisionTarget = new Target(collision);
                ignoredTargets.Add(collisionTarget);
                arc.Initialize(
                    arcLifetime, initialWidth, widthMultiplier, minWidth, branchTries,

                    minSpreadDistance, minSpreadDistanceMultiplier,
                    maxSpreadDistance, maxSpreadDistanceMultiplier,
                    minSpreadAngle, minSpreadAngleMultiplier,
                    maxSpreadAngle, maxSpreadAngleMultiplier,
                    spreadChance, spreadChanceMultiplier,

                    minBranchDistance, minBranchDistanceMultiplier,
                    maxBranchDistance, maxBranchDistanceMultiplier,
                    minBranchAngle, minBranchAngleMultiplier,
                    maxBranchAngle, maxBranchAngleMultiplier,
                    branchChance, branchChanceMultiplier,
                    ref ignoredTargets, out List<Arc> arcs);

                if (arcs != null)
                {
                    foreach (Arc nextArc in arcs)
                    {
                        if (nextArc.arcSegment != null)
                        {
                            nextArc.arcSegment.lineRenderer.startColor = arcGradient.Evaluate(Mathf.Clamp(0.0f, nextArc.maxRecursion, nextArc.recursion) / nextArc.maxRecursion);
                            nextArc.arcSegment.lineRenderer.endColor = nextArc.arcSegment.lineRenderer.startColor;
                        }

                        foreach (Target target in nextArc.targets)
                        {
                            Health targetHealth = target.gameObject.GetComponentInParent<Health>();
                            targetHealth.Damage(new DamageInfo(origin, nextArc.gameObject, damage * Random.Range(2.5f, 5.0f), knockback, armorPenetration, critChance, critDamage));
                        }
                    }

                    if (arcs.Count == 0)
                    {
                        Health collisionTargetHealth = collisionTarget.gameObject.GetComponentInParent<Health>();
                        collisionTargetHealth.Damage(new DamageInfo(origin, gameObject, damage * Random.Range(2.5f, 5.0f), knockback, armorPenetration, critChance, critDamage));
                    }
                }
                Kill();
            }
        }

        protected override void OnLostTarget()
        {
            Kill();
        }
    } 
}
