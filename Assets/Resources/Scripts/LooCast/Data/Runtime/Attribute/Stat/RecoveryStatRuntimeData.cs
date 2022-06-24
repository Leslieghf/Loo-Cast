using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "RecoveryStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/RecoveryStatRuntimeData", order = 0)]
    public sealed class RecoveryStatRuntimeData : StatRuntimeData
    {
        public FloatReference HealthRegenrationMultiplier;
    } 
}
