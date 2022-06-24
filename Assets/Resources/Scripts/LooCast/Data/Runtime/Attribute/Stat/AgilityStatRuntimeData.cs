using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "AgilityStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/AgilityStatRuntimeData", order = 0)]
    public sealed class AgilityStatRuntimeData : StatRuntimeData
    {
        public FloatReference MovementSpeedMultiplier;
    } 
}
