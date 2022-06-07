using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Health
{
    using Random;
    using Orb;
    using Sound;
    using UI.Canvas;
    using Attribute.Stat;
    using Manager;

    public class StationHealth : Health
    {
        protected WorldSpaceCanvas canvas;
        protected GameSoundHandler soundHandler;
        protected float magnetDropChance;
        protected float xpDropAmount;
        protected GameObject xpOrbPrefab;
        protected GameObject magnetOrbPrefab;


        public override void Initialize(float maxHealth, float regenerationAmount, int defense)
        {
            base.Initialize(maxHealth: maxHealth, regenerationAmount: regenerationAmount, defense: defense);

            canvas = FindObjectOfType<WorldSpaceCanvas>();
            soundHandler = FindObjectOfType<GameSoundHandler>();
            magnetDropChance = 1.0f * Stats.randomChanceMultiplier;
            xpDropAmount = 100.0f;
            xpOrbPrefab = Resources.Load<GameObject>("Prefabs/ExperienceOrb");
            magnetOrbPrefab = Resources.Load<GameObject>("Prefabs/MagnetOrb");
        }

        public override void Kill()
        {
            if (isAlive)
            {
                base.Kill();

                GameObject xpOrbObject = Instantiate(xpOrbPrefab, transform.position, Quaternion.identity);
                xpOrbObject.transform.localScale *= 2.5f;
                ExperienceOrb xpOrb = xpOrbObject.GetComponent<ExperienceOrb>();
                xpOrb.Initialize();
                xpOrb.SetExperience(xpDropAmount);
                GameSceneManager.Instance.SoundHandler.SoundBigExplosion();

                Destroy(gameObject);
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

            soundHandler.SoundHit();
        }
    }
}
