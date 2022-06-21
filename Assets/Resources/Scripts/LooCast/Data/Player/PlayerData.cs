using System;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Player
{
    using Health;

    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player/PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        public PlayerHealthData healthData;
    }
}
