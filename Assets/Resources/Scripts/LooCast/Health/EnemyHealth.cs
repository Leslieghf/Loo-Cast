using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Health
{
    using Indicator;
    using Random;
    using Orb;
    using Sound;
    using UI.Canvas;
    using Attribute.Stat;

    public class EnemyHealth : Health
    {
        protected WorldSpaceCanvas canvas;
        protected GameSoundHandler soundHandler;
        protected float magnetDropChance;
        protected float xpDropChance;
        protected GameObject xpOrbPrefab;
        protected GameObject magnetOrbPrefab;


        public override void Initialize(float maxHealth, float regenerationAmount, int defense)
        {
            base.Initialize(maxHealth: maxHealth, regenerationAmount: regenerationAmount, defense: defense);

            canvas = FindObjectOfType<WorldSpaceCanvas>();
            soundHandler = FindObjectOfType<GameSoundHandler>();
            magnetDropChance = 1.0f * Stats.randomChanceMultiplier;
            xpDropChance = 100.0f * Stats.randomChanceMultiplier;
            xpOrbPrefab = Resources.Load<GameObject>("Prefabs/ExperienceOrb");
            magnetOrbPrefab = Resources.Load<GameObject>("Prefabs/MagnetOrb");
        }

        public override void Kill()
        {
            if (isAlive)
            {
                base.Kill();

                if (Random.Range(0.0f, 100.0f) <= xpDropChance)
                {
                    GameObject xpOrbObject = Instantiate(xpOrbPrefab, transform.position, Quaternion.identity);
                    ExperienceOrb xpOrb = xpOrbObject.GetComponent<ExperienceOrb>();
                    xpOrb.Initialize();
                    xpOrb.SetExperience(1); 
                }

                if (Random.Range(0.0f, 100.0f) <= magnetDropChance)
                {
                    GameObject magnetOrbObject = Instantiate(magnetOrbPrefab, transform.position, Quaternion.identity);
                    MagnetOrb magnetOrb = magnetOrbObject.GetComponent<MagnetOrb>();
                    magnetOrb.Initialize();
                }
            }
        }

        public override void Damage(DamageInfo damageInfo)
        {
            if (Random.Range(0.0f, 1.0f) < 0.1f * ((ChanceStat)Stats.GetStat("ChanceStat")).randomChanceMultiplier)
            {
                damageInfo.damage *= 5.0f;
            }

            damageInfo.damage *= ((MightStat)Stats.GetStat("MightStat")).damageMultiplier;

            base.Damage(damageInfo);

            Vector2 worldPos = new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));

            GameObject damageIndicator = Instantiate(Resources.Load<GameObject>("Prefabs/DamageIndicator"), worldPos, Quaternion.identity, canvas.transform);
            damageIndicator.GetComponent<DamageIndicator>().Initialize(damageInfo.damage);

            Vector3 knockbackDirection = damageInfo.origin.transform.position - transform.position;
            if (damageInfo.knockback != 0.0f)
            {
                GetComponent<Rigidbody2D>().AddForce(knockbackDirection.normalized * -250f * damageInfo.knockback, ForceMode2D.Impulse);
            }
            
            soundHandler.SoundHit();
        }
    } 
}
