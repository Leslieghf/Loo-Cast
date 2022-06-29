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
        public Stats Stats;

        protected GameSoundHandler soundHandler;
        protected float magnetDropChance;
        protected float experienceDropChance;
        protected float experienceDropAmount;
        protected GameObject experienceOrbPrefab;
        protected GameObject magnetOrbPrefab;


        public void Initialize(EnemyHealthData data)
        {
            base.Initialize(data);

            soundHandler = FindObjectOfType<GameSoundHandler>();
            magnetDropChance = data.BaseMagnetDropChance.Value * Stats.RandomChanceMultiplier;
            experienceDropChance = data.BaseExperienceDropChance.Value * Stats.RandomChanceMultiplier;
            experienceDropAmount = data.BaseExperienceDropAmount.Value;
            experienceOrbPrefab = data.ExperienceOrbPrefab;
            magnetOrbPrefab = data.MagnetOrbPrefab;
        }

        public override void Kill()
        {
            if (isAlive)
            {
                base.Kill();

                if (Random.Range(0.0f, 1.0f) <= experienceDropChance)
                {
                    GameObject xpOrbObject = Instantiate(experienceOrbPrefab, transform.position, Quaternion.identity);
                    ExperienceOrb xpOrb = xpOrbObject.GetComponent<ExperienceOrb>();
                    xpOrb.Initialize();
                    xpOrb.SetExperience(experienceDropAmount); 
                }

                if (Random.Range(0.0f, 1.0f) <= magnetDropChance)
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
