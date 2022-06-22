using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "EgoStatData", menuName = "Data/Runtime/Attribute/Stat/EgoStatData", order = 0)]
    public sealed class EgoStatData : StatData
    {
        public FloatReference DamageReflection;
    } 
}
