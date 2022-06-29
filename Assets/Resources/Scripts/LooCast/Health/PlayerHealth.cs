using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Health
{
    using Sound;
    using UI.Bar;
    using UI.Screen;
    using Attribute.Stat;
    using Manager;
    using Data.Health;

    public class PlayerHealth : Health
    {
        public Stats Stats;

        private HealthBar healthBar;
        private GameSoundHandler soundHandler;
        private DeathScreen deathScreen;

        public void Initialize(PlayerHealthData data)
        {
            base.Initialize(data);

            maxHealth = data.MaxHealth * Stats.HealthMultiplier;
            health = data.MaxHealth * Stats.HealthMultiplier;
            regenerationAmount = data.RegenerationAmount * Stats.HealthRegenrationMultiplier;
            defense = data.Defense + Stats.DefenseIncrease;

            healthBar = FindObjectOfType<HealthBar>();
            healthBar.Initialize(maxHealth, maxHealth);

            soundHandler = FindObjectOfType<GameSoundHandler>();
            deathScreen = FindObjectOfType<DeathScreen>();
        }

        protected override void SetHealth(float health)
        {
            base.SetHealth(health);
            if (healthBar != null)
            {
                healthBar.SetValue(health);
            }
        }

        protected override void SetMaxHealth(float maxHealth)
        {
            base.SetMaxHealth(maxHealth);
            if (healthBar != null)
            {
                healthBar.SetMaxValue(maxHealth);
            }
        }

        public override void Kill()
        {
            if (isAlive)
            {
                base.Kill();
                GameSceneManager.Pause();
                soundHandler.SoundDeath();
                deathScreen.SetVisibility(true);
            }
        }
    } 
}
