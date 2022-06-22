using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "AgilityStatData", menuName = "Data/Runtime/Attribute/Stat/AgilityStatData", order = 0)]
    public sealed class AgilityStatData : StatData
    {
        public FloatReference MovementSpeedMultiplier;
    } 
}
