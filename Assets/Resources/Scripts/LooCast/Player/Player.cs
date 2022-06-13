using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Player
{
    using Util;
    using Health;
    using Target;
    using Movement;
    using Weapon;
    using Particle;
    using Currency;
    using Experience;
    using Attribute.Stat;

    [RequireComponent(typeof(PlayerHealth), typeof(Targeting), typeof(PlayerMovement)), DisallowMultipleComponent]
    public class Player : ExtendedMonoBehaviour
    {
        public PlayerHealth Health { get; private set; }
        public Targeting Targeting { get; private set; }
        public Experience Experience { get; private set; }
        public PlayerMovement Movement { get; private set; }
        public Dictionary<string, Weapon> Weapons { get; private set; }
        public ParticleSystem ParticleSystem { get; private set; }

        protected float baseMaxHealth = 100.0f;
        protected float baseRegeneration = 5.0f;
        protected int baseDefense = 0;

        public virtual void Initialize()
        {
            Health = GetComponent<PlayerHealth>();
            Health.Initialize(
                maxHealth: baseMaxHealth * Stats.healthMultiplier,
                regenerationAmount: baseRegeneration * Stats.healthRegenrationMultiplier,
                defense: baseDefense + Stats.defenseIncrease
                );

            Targeting = GetComponent<Targeting>();
            Targeting.Initialize();
            Targeting.radius = 50.0f;

            Weapons = new Dictionary<string, Weapon>();

            MultiplexerWeapon multiplexerWeapon = gameObject.AddComponent<MultiplexerWeapon>();
            multiplexerWeapon.Initialize();
            multiplexerWeapon.enabled = true;
            multiplexerWeapon.attackTimer = multiplexerWeapon.attackDelay;
            Weapons.Add("MultiplexerWeapon", multiplexerWeapon);

            LaserEmitterWeapon laserEmitterWeapon = gameObject.AddComponent<LaserEmitterWeapon>();
            laserEmitterWeapon.Initialize();
            laserEmitterWeapon.enabled = true;
            laserEmitterWeapon.attackTimer = laserEmitterWeapon.attackDelay;
            Weapons.Add("LaserEmitterWeapon", laserEmitterWeapon);

            FreezeRayWeapon freezeRayWeapon = gameObject.AddComponent<FreezeRayWeapon>();
            freezeRayWeapon.Initialize();
            freezeRayWeapon.enabled = true;
            freezeRayWeapon.attackTimer = freezeRayWeapon.attackDelay;
            Weapons.Add("FreezeRayWeapon", freezeRayWeapon);

            ChargedPlasmaLauncherWeapon chargedPlasmaLauncherWeapon = gameObject.AddComponent<ChargedPlasmaLauncherWeapon>();
            chargedPlasmaLauncherWeapon.Initialize();
            chargedPlasmaLauncherWeapon.enabled = true;
            chargedPlasmaLauncherWeapon.attackTimer = chargedPlasmaLauncherWeapon.attackDelay;
            Weapons.Add("ChargedPlasmaLauncherWeapon", chargedPlasmaLauncherWeapon);


            Experience = FindObjectOfType<Experience>();
            Experience.Initialize();

            ParticleSystem = GetComponentInChildren<ParticleSystem>();
            ParticleSystem.Initialize();

            Movement = GetComponent<PlayerMovement>();
            Movement.Initialize();
            Movement.onMovementDisabled.AddListener(ParticleSystem.PauseParticleSpawning);
            Movement.onMovementEnabled.AddListener(ParticleSystem.ResumeParticleSpawning);
            Movement.onStartAccelerating.AddListener(ParticleSystem.ResumeParticleSpawning);
            Movement.onStopAccelerating.AddListener(ParticleSystem.PauseParticleSpawning);
        }

        protected override void Cycle()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                Tokens.SetBalance(Tokens.GetBalance() + 100);
            }

            if (Input.GetKeyDown(KeyCode.F2))
            {
                Tokens.SetBalance(Tokens.GetBalance() - 100);
            }

            if (Input.GetKeyDown(KeyCode.F3))
            {
                Coins.SetBalance(Coins.GetBalance() + 1000);
            }

            if (Input.GetKeyDown(KeyCode.F4))
            {
                Coins.SetBalance(Coins.GetBalance() - 1000);
            }

            if (Input.GetKeyDown(KeyCode.F6))
            {
                Stats.Cheat();
            }

            //if (Input.GetKey(KeyCode.Alpha1))
            //{
            //    Weapons.TryGetValue("MultiplexerWeapon", out Weapon weapon);
            //    weapon.TryFire();
            //}
            //
            //if (Input.GetKey(KeyCode.Alpha2))
            //{
            //    Weapons.TryGetValue("LaserEmitterWeapon", out Weapon weapon);
            //    weapon.TryFire();
            //}
            //
            //if (Input.GetKey(KeyCode.Alpha3))
            //{
            //    Weapons.TryGetValue("FreezeRayWeapon", out Weapon weapon);
            //    weapon.TryFire();
            //}
            //
            //if (Input.GetKey(KeyCode.Alpha4))
            //{
            //    Weapons.TryGetValue("ChargedPlasmaLauncherWeapon", out Weapon weapon);
            //    weapon.TryFire();
            //}
        }
    } 
}