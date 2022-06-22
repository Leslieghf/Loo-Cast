using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "FateStatData", menuName = "Data/Runtime/Attribute/Stat/FateStatData", order = 0)]
    public sealed class FateStatData : StatData
    {
        public FloatReference NegativeEventChanceMultiplier;
    } 
}
