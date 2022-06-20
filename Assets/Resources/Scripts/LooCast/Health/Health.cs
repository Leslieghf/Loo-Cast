using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Health
{
    using Util;
    using Random;
    using Attribute.Stat;

    public abstract class Health : ExtendedMonoBehaviour
    {
        protected float health;
        protected float maxHealth;
        protected float regenerationAmount;
        protected float regenerationTime;
        protected float regenerationTimer;
        protected int defense;

        protected bool isAlive = true;
        public UnityEvent onKilled;

        public virtual void Initialize(float maxHealth, float regenerationAmount, int defense)
        {
            this.maxHealth = maxHealth;
            health = maxHealth;

            this.regenerationAmount = regenerationAmount;
            regenerationTime = 1.0f;
            regenerationTimer = 0.0f;

            this.defense = defense;

            onKilled = new UnityEvent();
        }

        protected override void Cycle()
        {
            regenerationTimer += Time.deltaTime;
            if (regenerationTimer >= regenerationTime)
            {
                regenerationTimer = 0.0f;
                Heal(regenerationAmount);
            }
        }

        public virtual void Damage(DamageInfo damageInfo)
        {
            float difficulty;
            if (!PlayerPrefs.HasKey("Difficulty"))
            {
                PlayerPrefs.SetFloat("Difficulty", 1.0f);
            }
            difficulty = PlayerPrefs.GetFloat("Difficulty");

            float damage = damageInfo.damage;
            float defense = this.defense * difficulty;
            if (damageInfo.armorPenetration >= defense)
            {
                defense = 0;
            }
            else
            {
                defense -= damageInfo.armorPenetration;
            }
            damage -= defense;
            if (damage <= 0)
            {
                return;
            }

            health -= damage;
            if (health <= 0)
            {
                health = 0;
                Kill();
            }
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