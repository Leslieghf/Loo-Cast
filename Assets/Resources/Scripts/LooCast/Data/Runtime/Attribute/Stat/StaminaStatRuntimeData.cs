using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "StaminaStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/StaminaStatRuntimeData", order = 0)]
    public sealed class StaminaStatRuntimeData : StatRuntimeData
    {
        public FloatReference DurationMultiplier;
    } 
}
