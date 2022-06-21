using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Enemy
{
    using Particle;
    using Manager;
    using Movement;
    using Util;
    using Health;
    using Target;
    using Experience;
    using Data.Enemy;
    using Data.Health;

    [RequireComponent(typeof(Movement), typeof(EnemyHealth)), DisallowMultipleComponent]
    public abstract class Enemy : ExtendedMonoBehaviour
    {
        public readonly static List<Enemy> enemies = new List<Enemy>();

        public EnemyData data;

        public Experience playerExperience { get; private set; }
        public new ParticleSystem particleSystem { get; private set; }
        public EnemyMovement movement { get; private set; }
        public EnemyHealth health { get; private set; }
        public Targeting playerTargeting { get; private set; }
        public UnityEvent onKilled { get; private set; }


        private void Start()
        {
            enemies.Add(this);

            playerExperience = FindObjectOfType<Experience>();

            particleSystem = GetComponentInChildren<ParticleSystem>();
            particleSystem.Initialize();

            movement = GetComponent<EnemyMovement>();
            movement.Initialize();
            movement.onMovementDisabled.AddListener(particleSystem.PauseParticleSpawning);
            movement.onMovementEnabled.AddListener(particleSystem.ResumeParticleSpawning);

            health = GetComponent<EnemyHealth>();
            health.Initialize(data.HealthData);
            health.onKilled.AddListener(Kill);

            playerTargeting = GameSceneManager.Instance.Player.Targeting;

            onKilled = new UnityEvent();
            health.onKilled.AddListener( () => { onKilled.Invoke(); } );
        }

        public virtual void Kill()
        {
            enemies.Remove(this);
            particleSystem.Kill();
            Destroy(gameObject);
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerHealth playerHealth = GameSceneManager.Instance.Player.Health;
                float difficulty;
                if (!PlayerPrefs.HasKey("Difficulty"))
                {
                    PlayerPrefs.SetFloat("Difficulty", 1.0f);
                }
                difficulty = PlayerPrefs.GetFloat("Difficulty");
                playerHealth.Damage(new DamageInfo(collision.gameObject, collision.gameObject, data.ContactDamage.Value * difficulty, 0, 0, 0, 0));
            }
        }
    } 
}
