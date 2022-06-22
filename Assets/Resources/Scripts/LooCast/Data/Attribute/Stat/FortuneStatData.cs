using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "FortuneStatData", menuName = "Data/Runtime/Attribute/Stat/FortuneStatData", order = 0)]
    public sealed class FortuneStatData : StatData
    {
        public FloatReference PositiveEventChanceMultiplier;
    } 
}
