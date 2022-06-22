using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "SanityStatData", menuName = "Data/Runtime/Attribute/Stat/SanityStatData", order = 0)]
    public sealed class SanityStatData : StatData
    {
        public FloatReference ProjectileSizeMultiplier;
    } 
}
