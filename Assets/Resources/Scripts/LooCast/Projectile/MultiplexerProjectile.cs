using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Projectile
{
    using Health;
    using Sound;
    using Target;
    using Random;

    public class MultiplexerProjectile : Projectile
    {
        public int fragments { get; protected set; }
        public int fragmentArmorPenetration { get; protected set; }
        public bool followTarget { get; protected set; }
        protected GameObject fragmentPrefab;
        protected GameSoundHandler soundHandler;

        public virtual void Initialize(Target target, GameObject origin, float damage, float critChance, float critDamage, float knockback, float speed, float size, float lifetime, int piercing, int armorPenetration, int fragments, int fragmentArmorPenetration, bool followTarget)
        {
            base.Initialize(target, origin, damage, critChance, critDamage, knockback, speed, size, lifetime, piercing, armorPenetration);
            fragmentPrefab = Resources.Load<GameObject>("Prefabs/MultiplexerFragmentProjectile");
            soundHandler = FindObjectOfType<GameSoundHandler>();
            this.fragments = fragments;
            this.fragmentArmorPenetration = fragmentArmorPenetration;
            this.followTarget = followTarget;

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
        }

        public virtual void Kill(Collider2D collision)
        {
            base.Kill();

            for (int i = 0; i < fragments; i++)
            {
                GameObject bulletObject = Instantiate(fragmentPrefab, transform.position, Quaternion.identity);
                bulletObject.transform.position += new Vector3(0, 0, 0.1f);
                bulletObject.GetComponent<MultiplexerFragmentProjectile>().Initialize(origin, collision, damage, critChance, critDamage, knockback, speed * 5.0f, size * 0.5f, 0.5f, piercing, fragmentArmorPenetration);
            }
            soundHandler.SoundShoot();
        }

        private void Update()
        {
            //if (followTarget && target != null && target.IsValid())
            //{
            //    Vector3 estimatedProjectileHitPos = transform.position;
            //    for (int i = 0; i < 3; i++)
            //    {
            //        float projectileArrivalTime = (target.transform.position - estimatedProjectileHitPos).magnitude / speed;
            //        Vector3 targetVelocity = target.gameObject.GetComponent<Rigidbody2D>().velocity;
            //        targetVelocity.y = 0;
            //        estimatedProjectileHitPos = target.transform.position + targetVelocity * projectileArrivalTime; 
            //    }
            //
            //    rb.velocity = (estimatedProjectileHitPos - transform.position).normalized * speed;
            //}
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
                    Kill(collision);
                    return;
                }
                if (System.Console.ReadKey().KeyChar.Equals('y'))
                {
                    //banana
                }
                else if (System.Console.ReadKey().KeyChar.Equals('n'))
                {
                    //no banana
                }
                pierced += 1;
                Health collisionHealth = collision.gameObject.GetComponentInParent<Health>();
                collisionHealth.Damage(new DamageInfo(origin, gameObject, damage * Random.Range(2.5f, 5.0f), knockback, armorPenetration));


                if (pierced > piercing)
                {
                    Kill(collision);
                    return;
                }
            }
        }

        protected override void OnLostTarget()
        {
            Kill();
        }
    } 
}
