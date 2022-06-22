using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "StaminaStatData", menuName = "Data/Runtime/Attribute/Stat/StaminaStatData", order = 0)]
    public sealed class StaminaStatData : StatData
    {
        public FloatReference DurationMultiplier;
    } 
}
