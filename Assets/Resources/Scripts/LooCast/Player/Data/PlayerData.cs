using System;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Player.Data
{
    using Health.Data;
    using Movement.Data;
    using Weapon.Data;

    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player/PlayerData", order = 0)]
    public sealed class PlayerData : ScriptableObject
    {
        public PlayerHealthData HealthData;
        public PlayerMovementData MovementData;
        public MultiplexerWeaponData MultiplexerWeaponData;
        public LaserEmitterWeaponData LaserEmitterWeaponData;
        public FreezeRayWeaponData FreezeRayWeaponData;
        public ChargedPlasmaLauncherWeaponData ChargedPlasmaLauncherWeaponData;
    }
}
