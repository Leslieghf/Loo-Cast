using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "PowerStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/PowerStatRuntimeData", order = 0)]
    public sealed class PowerStatRuntimeData : StatRuntimeData
    {
        public FloatReference KnockbackMultiplier;
    } 
}
