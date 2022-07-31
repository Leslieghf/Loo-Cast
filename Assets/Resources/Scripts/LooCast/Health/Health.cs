using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Health
{
    using Core;
    using Data;
    using Random;
    using Indicator;
    using UI.Canvas;

    public abstract class Health : ExtendedMonoBehaviour
    {
        protected float health;
        protected float maxHealth;
        protected float regenerationAmount;
        protected float regenerationTime;
        protected float regenerationTimer;
        protected int defense;
        protected bool isAlive;

        public UnityEvent onKilled;
        protected WorldSpaceCanvas canvas;

        public void Initialize(HealthData data)
        {
            maxHealth = data.BaseMaxHealth.Value;
            health = maxHealth;

            regenerationAmount = data.BaseRegenerationAmount.Value;
            regenerationTime = 1.0f;
            regenerationTimer = 0.0f;

            defense = data.BaseDefense.Value;

            isAlive = true;

            onKilled = new UnityEvent();

            canvas = FindObjectOfType<WorldSpaceCanvas>();
        }

        protected override void OnPauseableUpdate()
        {
            Heal(regenerationAmount * Time.deltaTime);
        }

        public virtual void Damage(DamageInfo damageInfo)
        {
            bool TryCriticalStrike(ref DamageInfo refDamageInfo)
            {
                if (Random.Range(0.0f, 1.0f) < refDamageInfo.critChance)
                {
                    refDamageInfo.damage = refDamageInfo.critDamage;
                    return true;
                }
                return false;
            }

            TryCriticalStrike(ref damageInfo);

            float defense = this.defense;
            if (damageInfo.armorPenetration >= defense)
            {
                defense = 0;
            }
            else
            {
                defense -= damageInfo.armorPenetration;
            }

            damageInfo.damage -= defense;
            if (damageInfo.damage <= 0)
            {
                return;
            }

            health -= damageInfo.damage;
            if (health <= 0)
            {
                health = 0;
                Kill();
            }
        }

        public virtual void IndicateDamage(DamageInfo damageInfo)
        {
            Vector2 worldPos = new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));
            GameObject damageIndicator = Instantiate(Resources.Load<GameObject>("Prefabs/DamageIndicator"), worldPos, Quaternion.identity, canvas.transform);
            damageIndicator.GetComponent<DamageIndicator>().Initialize(damageInfo.damage);
        }

        public virtual void Heal(float health)
        {
            this.health += health;
            if (this.health > maxHealth)
            {
                this.health = maxHealth;
            }
        }

        public virtual void Kill()
        {
            isAlive = false;
            onKilled.Invoke();
        }

        public virtual void Knockback(DamageInfo damageInfo)
        {
            if (damageInfo.knockback != 0.0f)
            {
                Vector3 knockbackDirection = damageInfo.origin.transform.position - transform.position;
                Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
                if (rigidbody != null)
                {
                    rigidbody.AddForce(knockbackDirection.normalized * -250f * damageInfo.knockback, ForceMode2D.Impulse); 
                }
            }
        }

        protected virtual float GetHealth()
        {
            return health;
        }
        protected virtual void SetHealth(float health)
        {
            this.health = health;
        }

        protected virtual float GetMaxHealth()
        {
            return maxHealth;
        }
        protected virtual void SetMaxHealth(float maxHealth)
        {
            this.maxHealth = maxHealth;
        }

        protected virtual float GetRegenerationAmount()
        {
            return regenerationAmount;
        }
        protected virtual void SetRegenerationAmount(float regenerationAmount)
        {
            this.regenerationAmount = regenerationAmount;
        }
    } 
}