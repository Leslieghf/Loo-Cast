using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LooCast.Enemy
{
    using Core;
    using Particle;
    using Manager;
    using Movement;
    using Health;
    using Target;
    using Experience;
    using Enemy.Data;

    [RequireComponent(typeof(Movement), typeof(EnemyHealth)), DisallowMultipleComponent]
    public abstract class Enemy : ExtendedMonoBehaviour
    {
        public readonly static List<Enemy> Enemies = new List<Enemy>();

        public EnemyData Data;
        public Experience PlayerExperience { get; private set; }
        public ParticleSystem ParticleSystem { get; private set; }
        public EnemyMovement Movement { get; private set; }
        public EnemyHealth Health { get; private set; }
        public Targeting PlayerTargeting { get; private set; }
        public UnityEvent OnKilled { get; private set; }


        private void Awake()
        {
            Enemies.Add(this);

            PlayerExperience = FindObjectOfType<Experience>();

            ParticleSystem = GetComponentInChildren<ParticleSystem>();
            ParticleSystem.Initialize();

            Movement = GetComponent<EnemyMovement>();
            Movement.Initialize();
            Movement.OnMovementDisabled.AddListener(ParticleSystem.PauseParticleSpawning);
            Movement.OnMovementEnabled.AddListener(ParticleSystem.ResumeParticleSpawning);

            Health = GetComponent<EnemyHealth>();
            Health.Initialize(Health.DataData);
            Health.onKilled.AddListener(Kill);

            PlayerTargeting = GameSceneManager.Instance.Player.Targeting;

            OnKilled = new UnityEvent();
            Health.onKilled.AddListener( () => { OnKilled.Invoke(); } );
        }

        public virtual void Kill()
        {
            Enemies.Remove(this);
            ParticleSystem.Kill();
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
                playerHealth.Damage(new DamageInfo(collision.gameObject, collision.gameObject, Data.ContactDamage.Value * difficulty, 0, 0, 0, 0));
            }
        }
    } 
}
