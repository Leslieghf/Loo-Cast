using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "ReflexesStatData", menuName = "Data/Runtime/Attribute/Stat/ReflexesStatData", order = 0)]
    public sealed class ReflexesStatData : StatData
    {
        public FloatReference ConsecutiveProjectileDelayMultiplier;
    } 
}
