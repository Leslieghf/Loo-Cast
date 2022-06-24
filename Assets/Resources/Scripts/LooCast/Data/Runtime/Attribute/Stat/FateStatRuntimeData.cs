using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "FateStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/FateStatRuntimeData", order = 0)]
    public sealed class FateStatRuntimeData : StatRuntimeData
    {
        public FloatReference NegativeEventChanceMultiplier;
    } 
}
