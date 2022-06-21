using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Health
{
    using Attribute.Stat;

    [CreateAssetMenu(fileName = "PlayerHealthData", menuName = "Data/Health/PlayerHealthData", order = 0)]
    public class PlayerHealthData : HealthData
    {
        public float MaxHealth
        {
            get
            {
                return BaseMaxHealth.Value * Stats.healthMultiplier;
            }
        }

        public float RegenerationAmount
        {
            get
            {
                return BaseRegenerationAmount.Value * Stats.healthRegenrationMultiplier;
            }
        }

        public int Defense
        {
            get
            {
                return BaseDefense.Value + Stats.defenseIncrease;
            }
        }
    } 
}
