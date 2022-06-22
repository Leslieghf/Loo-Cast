using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "MindStatData", menuName = "Data/Runtime/Attribute/Stat/MindStatData", order = 0)]
    public sealed class MindStatData : StatData
    {
        public FloatReference RangeMultiplier;
    } 
}
