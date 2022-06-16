using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Station
{
    using Target;
    using Weapon;
    using Data.Weapon;
    using Health;
    using Data.Station;

    [RequireComponent(typeof(Targeting), typeof(MultiplexerWeapon))]
    public class PlayerStation : Station
    {
        public Targeting targeting { get; private set; }
        public MultiplexerWeapon defensiveWeapon { get; private set; }

        public PlayerStationData stationData;
        public MultiplexerWeaponData defensiveMultiplexerWeaponData;

        private void Start()
        {
            Initialize(stationData);
        }

        public void Initialize(PlayerStationData data)
        {
            base.Initialize<PlayerStationHealth>(data);

            targeting = GetComponent<Targeting>();
            targeting.Initialize();
            targeting.radius = data.TargetingRadius.Value;

            defensiveWeapon = GetComponent<MultiplexerWeapon>();
            defensiveWeapon.Initialize(defensiveMultiplexerWeaponData);
            defensiveWeapon.enabled = true;
            defensiveWeapon.attackTimer = defensiveWeapon.attackDelay;
        }
    } 
}
