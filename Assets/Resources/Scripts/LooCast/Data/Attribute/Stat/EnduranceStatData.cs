using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "EnduranceStatData", menuName = "Data/Runtime/Attribute/Stat/EnduranceStatData", order = 0)]
    public sealed class EnduranceStatData : StatData
    {
        public FloatReference EnergyRegenerationMultiplier;
    } 
}
