using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Projectile
{
    using Health;
    using Random;

    public class MultiplexerFragmentProjectile : Projectile
    {
        public virtual void Initialize(GameObject origin, Collider2D ignoreCollider, float damage, float critChance, float critDamage, float knockback, float speed, float size, float lifetime, int piercing, int armorPenetration)
        {
            base.Initialize(null, origin, damage, critChance, critDamage, knockback, speed, size, lifetime, piercing, armorPenetration);

            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), ignoreCollider);

            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            Vector3 direction = new Vector3(x, y, 0f).normalized;
            rb.velocity = direction * speed;

            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg - 90.0f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
                collisionHealth.Damage(new DamageInfo(origin, gameObject, damage * Random.Range(2.5f, 5.0f), knockback, armorPenetration));

                if (pierced > piercing)
                {
                    Kill();
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
