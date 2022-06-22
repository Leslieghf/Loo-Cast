using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "MightStatData", menuName = "Data/Runtime/Attribute/Stat/MightStatData", order = 0)]
    public sealed class MightStatData : StatData
    {
        public FloatReference DamageMultiplier;
    } 
}
