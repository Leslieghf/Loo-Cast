using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "FortuneStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/FortuneStatRuntimeData", order = 0)]
    public sealed class FortuneStatRuntimeData : StatRuntimeData
    {
        public FloatReference PositiveEventChanceMultiplier;
    } 
}
