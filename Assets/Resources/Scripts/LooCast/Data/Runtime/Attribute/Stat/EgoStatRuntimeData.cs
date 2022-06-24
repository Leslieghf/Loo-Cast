using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "EgoStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/EgoStatRuntimeData", order = 0)]
    public sealed class EgoStatRuntimeData : StatRuntimeData
    {
        public FloatReference DamageReflection;
    } 
}
