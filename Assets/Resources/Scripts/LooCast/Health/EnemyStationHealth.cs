using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Health
{
    using Random;
    using Orb;
    using Attribute.Stat;
    using Data.Health;

    public class EnemyStationHealth : StationHealth
    {
        protected float experienceDropChance;
        protected float experienceDropAmount;
        protected GameObject experienceOrbPrefab;

        public void Initialize(EnemyStationHealthData data)
        {
            base.Initialize(data);

            experienceDropChance = data.BaseExperienceDropChance.Value;
            experienceDropAmount = data.BaseExperienceDropAmount.Value;
            experienceOrbPrefab = data.ExperienceOrbPrefab;
        }

        public override void Kill()
        {
            base.Kill();

            if (!isAlive && Random.Range(0.0f, 1.0f) < experienceDropChance)
            {
                GameObject xpOrbObject = Instantiate(experienceOrbPrefab, transform.position, Quaternion.identity);
                xpOrbObject.transform.localScale *= 2.5f;
                ExperienceOrb xpOrb = xpOrbObject.GetComponent<ExperienceOrb>();
                xpOrb.Initialize();
                xpOrb.SetExperience(experienceDropAmount);
            }
        }

        public override void Damage(DamageInfo damageInfo)
        {
            if (Random.Range(0.0f, 1.0f) < 0.1f * Stats.RandomChanceMultiplier)
            {
                damageInfo.damage *= 5.0f;
            }

            base.Damage(damageInfo);
        }
    } 
}
