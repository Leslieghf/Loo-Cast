using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Projectile
{
    using Random;
    using Health;

    [RequireComponent(typeof(LineRenderer), typeof(BoxCollider2D))]
    public class LaserProjectile : Projectile
    {
        private LineRenderer lineRenderer;
        private new BoxCollider2D collider;

        public float laserLength { get; protected set; }
        private bool isDeploying = true;
        private bool isRetracting = false;
        private Vector3 velocity;

        public virtual void Initialize(Target.Target target, GameObject origin, float damage, float critChance, float critDamage, float knockback, float speed, float size, float lifetime, int piercing, int armorPenetration, float laserLength)
        {
            base.Initialize(target, origin, damage, critChance, critDamage, knockback, speed, size, lifetime, piercing, armorPenetration);
            lineRenderer = GetComponent<LineRenderer>();
            collider = GetComponent<BoxCollider2D>();
            this.laserLength = laserLength;

            if (target == null || target.transform == null)
            {
                float x = Random.Range(-1f, 1f);
                float y = Random.Range(-1f, 1f);
                Vector3 direction = new Vector3(x, y, 0f).normalized;
                velocity = direction;
            }
            else
            {
                float projectileArrivalTime = (target.transform.position - origin.transform.position).magnitude / speed;
                Vector3 targetVelocity = target.gameObject.GetComponent<Rigidbody2D>().velocity;
                targetVelocity.z = 0;
                Vector3 estimatedProjectileHitPos = target.transform.position + targetVelocity * projectileArrivalTime;

                velocity = (estimatedProjectileHitPos - transform.position).normalized;
            }
            velocity *= speed;

            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
        }

        protected override void Cycle()
        {
            base.Cycle();

            if (isDeploying)
            {
                Vector3 newPos = lineRenderer.GetPosition(1) + new Vector3(0, (velocity * Time.deltaTime).magnitude, 0);
                if (newPos.y >= laserLength)
                {
                    newPos.y = laserLength;
                    isDeploying = false;
                    rb.velocity = velocity;
                }
                lineRenderer.SetPosition(1, newPos);
                collider.size = new Vector2(collider.size.x, newPos.y);
                collider.offset = new Vector2(0.0f, newPos.y / 2);
            }

            if (isRetracting)
            {
                Vector3 targetPos = lineRenderer.GetPosition(1);
                Vector3 newPos = lineRenderer.GetPosition(0) + new Vector3(0, (velocity * Time.deltaTime).magnitude, 0);
                if (newPos.y >= targetPos.y)
                {
                    newPos.y = targetPos.y;
                    isRetracting = false;
                }
                lineRenderer.SetPosition(0, newPos);
                

                if (!isRetracting)
                {
                    Kill();
                }
            }
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
                if (pierced > piercing)
                {
                    Kill();
                    return;
                }

                pierced += 1;
                Health collisionHealth = collision.gameObject.GetComponentInParent<Health>();
                collisionHealth.Damage(new DamageInfo(origin, gameObject, damage * Random.Range(2.5f, 5.0f), knockback, armorPenetration, critChance, critDamage));

                if (pierced > piercing)
                {
                    isDeploying = false;
                    isRetracting = true;
                    rb.velocity = Vector3.zero;
                }

                if (CheckTags("EnemyStation"))
                {
                    Kill();
                }
            }
        }
    } 
}
