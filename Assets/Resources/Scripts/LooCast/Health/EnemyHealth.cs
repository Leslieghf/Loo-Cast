using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Health
{
    using Random;
    using Orb;
    using Sound;
    using Data.Health;
    using Attribute.Stat;

    public class EnemyHealth : Health
    {
        protected GameSoundHandler soundHandler;
        protected float magnetDropChance;
        protected float xpDropChance;
        protected GameObject xpOrbPrefab;
        protected GameObject magnetOrbPrefab;


        public void Initialize(EnemyHealthData data)
        {
            base.Initialize(data);

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
            base.Damage(damageInfo);

            Knockback(damageInfo);
            IndicateDamage(damageInfo);
            soundHandler.SoundHit();
        }
    } 
}
