using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Health
{
    using Sound;
    using UI.Bar;
    using UI.Screen;
    using Manager;

    public class PlayerHealth : Health
    {
        private HealthBar healthBar;
        private GameSoundHandler soundHandler;
        private DeathScreen deathScreen;

        public override void Initialize(float maxHealth, float regenerationAmount, int defense)
        {
            base.Initialize(maxHealth: maxHealth, regenerationAmount: regenerationAmount, defense: defense);

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
