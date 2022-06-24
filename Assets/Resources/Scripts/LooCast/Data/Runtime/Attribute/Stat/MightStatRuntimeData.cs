using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "MightStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/MightStatRuntimeData", order = 0)]
    public sealed class MightStatRuntimeData : StatRuntimeData
    {
        public FloatReference DamageMultiplier;
    } 
}
