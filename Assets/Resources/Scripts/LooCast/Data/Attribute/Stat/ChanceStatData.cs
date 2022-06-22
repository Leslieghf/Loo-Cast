using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "ChanceStatData", menuName = "Data/Runtime/Attribute/Stat/ChanceStatData", order = 0)]
    public sealed class ChanceStatData : StatData
    {
        public FloatReference RandomChanceMultiplier;
    } 
}
