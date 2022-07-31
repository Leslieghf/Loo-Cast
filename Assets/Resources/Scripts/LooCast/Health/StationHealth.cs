using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Health
{
    using Sound;
    using UI.Canvas;
    using Manager;
    using Health.Data;

    public class StationHealth : Health
    {
        protected GameSoundHandler soundHandler;

        public void Initialize(StationHealthData data)
        {
            base.Initialize(data);

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
