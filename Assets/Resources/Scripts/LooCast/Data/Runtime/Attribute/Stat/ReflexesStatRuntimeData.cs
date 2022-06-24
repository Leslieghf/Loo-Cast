using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "ReflexesStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/ReflexesStatRuntimeData", order = 0)]
    public sealed class ReflexesStatRuntimeData : StatRuntimeData
    {
        public FloatReference ConsecutiveProjectileDelayMultiplier;
    } 
}
