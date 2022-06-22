using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "RecoveryStatData", menuName = "Data/Runtime/Attribute/Stat/RecoveryStatData", order = 0)]
    public sealed class RecoveryStatData : StatData
    {
        public FloatReference HealthRegenrationMultiplier;
    } 
}
