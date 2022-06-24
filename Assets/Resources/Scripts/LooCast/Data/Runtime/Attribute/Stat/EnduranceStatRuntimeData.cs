using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "EnduranceStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/EnduranceStatRuntimeData", order = 0)]
    public sealed class EnduranceStatRuntimeData : StatRuntimeData
    {
        public FloatReference EnergyRegenerationMultiplier;
    } 
}
