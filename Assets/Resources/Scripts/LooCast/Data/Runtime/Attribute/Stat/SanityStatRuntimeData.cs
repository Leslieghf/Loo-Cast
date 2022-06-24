using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "SanityStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/SanityStatRuntimeData", order = 0)]
    public sealed class SanityStatRuntimeData : StatRuntimeData
    {
        public FloatReference ProjectileSizeMultiplier;
    } 
}
