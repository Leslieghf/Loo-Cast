using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Health
{
    using Random;
    using Sound;
    using UI.Canvas;
    using Attribute.Stat;
    using Manager;

    public class StationHealth : Health
    {
        protected WorldSpaceCanvas canvas;
        protected GameSoundHandler soundHandler;

        public override void Initialize(float baseMaxHealth, float baseRegenerationAmount, int baseDefense)
        {
            base.Initialize(
                maxHealth: baseMaxHealth,
                regenerationAmount: baseRegenerationAmount,
                defense: baseDefense
                );

            canvas = FindObjectOfType<WorldSpaceCanvas>();
            soundHandler = FindObjectOfType<GameSoundHandler>();
        }

        public override void Kill()
        {
            if (isAlive)
            {
                base.Kill();

                GameSceneManager.Instance.SoundHandler.SoundBigExplosion();

                Destroy(gameObject);
            }
        }
    }
}
