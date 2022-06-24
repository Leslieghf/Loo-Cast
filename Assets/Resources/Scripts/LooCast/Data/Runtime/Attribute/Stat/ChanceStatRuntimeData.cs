using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "ChanceStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/ChanceStatRuntimeData", order = 0)]
    public sealed class ChanceStatRuntimeData : StatRuntimeData
    {
        public FloatReference RandomChanceMultiplier;
    } 
}
