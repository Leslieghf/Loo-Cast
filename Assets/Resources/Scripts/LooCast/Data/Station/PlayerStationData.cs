using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Station
{
    using Weapon;
    using Health;

    [CreateAssetMenu(fileName = "PlayerStationData", menuName = "Data/Station/PlayerStationData", order = 0)]
    public sealed class PlayerStationData : StationData
    {
        public PlayerStationHealthData HealthData;
        public MultiplexerWeaponData DefensiveMultiplexerWeaponData;
        public FloatReference TargetingRadius;
    } 
}
