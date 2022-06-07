using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Health
{
    using Util;

    public class Health : ExtendedMonoBehaviour
    {
        protected float health
        {
            get
            {
                return GetHealth();
            }

            set
            {
                SetHealth(value);
            }
        }
        protected float _health;
        protected float maxHealth
        {
            get
            {
                return GetMaxHealth();
            }

            set
            {
                SetMaxHealth(value);
            }
        }
        protected float _maxHealth;

        protected float regenerationAmount
        {
            get
            {
                return GetRegenerationAmount();
            }

            set
            {
                SetRegenerationAmount(value);
            }
        }
        protected float _regenerationAmount;


        protected float regenerationTime;
        protected float regenerationTimer;

        protected bool isAlive = true;
        protected int defense;
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
            return _health;
        }
        protected virtual void SetHealth(float health)
        {
            _health = health;
        }

        protected virtual float GetMaxHealth()
        {
            return _maxHealth;
        }
        protected virtual void SetMaxHealth(float maxHealth)
        {
            _maxHealth = maxHealth;
        }

        protected virtual float GetRegenerationAmount()
        {
            return _regenerationAmount;
        }
        protected virtual void SetRegenerationAmount(float regenerationAmount)
        {
            _regenerationAmount = regenerationAmount;
        }
    } 
}