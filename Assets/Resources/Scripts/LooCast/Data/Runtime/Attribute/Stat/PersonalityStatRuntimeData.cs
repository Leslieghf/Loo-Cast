using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "PersonalityStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/PersonalityStatRuntimeData", order = 0)]
    public sealed class PersonalityStatRuntimeData : StatRuntimeData
    {
        public FloatReference ProjectileSpeedMultiplier;
    } 
}
