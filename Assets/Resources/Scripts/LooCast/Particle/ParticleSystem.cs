using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Particle
{
    using Util;

    [RequireComponent(typeof(UnityEngine.ParticleSystem))]
    public class ParticleSystem : ExtendedMonoBehaviour
    {
        public new UnityEngine.ParticleSystem particleSystem { get; protected set; }
        protected UnityEngine.ParticleSystem.EmissionModule emission;
        public bool destructionScheduled;

        public virtual void Initialize()
        {
            particleSystem = GetComponent<UnityEngine.ParticleSystem>();
            emission = particleSystem.emission;
            destructionScheduled = false;
        }

        protected override void Cycle()
        {
            if (destructionScheduled)
            {
                if (particleSystem.particleCount == 0)
                {
                    Destroy(gameObject);
                }
            }
        }

        public void PauseParticleSpawning()
        {
            emission.enabled = false;
        }

        public void ResumeParticleSpawning()
        {
            emission.enabled = true;
        }

        public void Kill()
        {
            transform.parent = null;
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            name += "[Destruction Scheduled]";
            PauseParticleSpawning();
            destructionScheduled = true;
        }

        protected override void OnPause()
        {
            base.OnPause();
            particleSystem.Pause();
        }

        protected override void OnResume()
        {
            base.OnResume();
            particleSystem.Play();
        }
    } 
}
