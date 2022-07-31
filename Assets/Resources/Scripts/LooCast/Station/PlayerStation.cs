using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Station
{
    using Target;
    using Weapon;
    using Weapon.Data;
    using Health;
    using Station.Data;

    [RequireComponent(typeof(PlayerStationHealth), typeof(Targeting), typeof(MultiplexerWeapon))]
    public class PlayerStation : Station
    {
        public PlayerStationData Data;
        public PlayerStationHealth Health { get; protected set; }
        public Targeting Targeting { get; private set; }
        public MultiplexerWeapon DefensiveWeapon { get; private set; }

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            Initialize(Data);

            Health = GetComponent<PlayerStationHealth>();
            Health.Initialize(Health.DataData);

            Targeting = GetComponent<Targeting>();
            Targeting.Initialize();
            Targeting.radius = Data.TargetingRadius.Value;

            DefensiveWeapon = GetComponent<MultiplexerWeapon>();
            DefensiveWeapon.Initialize(Data.DefensiveMultiplexerWeaponData);
            DefensiveWeapon.enabled = true;
            DefensiveWeapon.attackTimer = DefensiveWeapon.attackDelay;
        }
    } 
}
