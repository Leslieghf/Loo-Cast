using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "VitalityStatData", menuName = "Data/Runtime/Attribute/Stat/VitalityStatData", order = 0)]
    public sealed class VitalityStatData : StatData
    {
        public FloatReference HealthMultiplier;
    } 
}
