using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Health
{
    using Attribute.Stat;

    [CreateAssetMenu(fileName = "PlayerHealthData", menuName = "Data/Health/PlayerHealthData", order = 0)]
    public class PlayerHealthData : StatData
    {
        public float MaxHealth
        {
            get
            {
                return BaseMaxHealth.Value * Stats.HealthMultiplier;
            }
        }

        public float RegenerationAmount
        {
            get
            {
                return BaseRegenerationAmount.Value * Stats.HealthRegenrationMultiplier;
            }
        }

        public int Defense
        {
            get
            {
                return BaseDefense.Value + Stats.DefenseIncrease;
            }
        }
    } 
}
