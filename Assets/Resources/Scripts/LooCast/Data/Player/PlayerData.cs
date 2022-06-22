using System;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Player
{
    using Health;
    using Weapon;

    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player/PlayerData", order = 0)]
    public sealed class PlayerData : ScriptableObject
    {
        public PlayerHealthData HealthData;
        public MultiplexerWeaponData MultiplexerWeaponData;
        public LaserEmitterWeaponData LaserEmitterWeaponData;
        public FreezeRayWeaponData FreezeRayWeaponData;
        public ChargedPlasmaLauncherWeaponData ChargedPlasmaLauncherWeaponData;
    }
}
