using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "ResilienceStatData", menuName = "Data/Runtime/Attribute/Stat/ResilienceStatData", order = 0)]
    public sealed class ResilienceStatData : StatData
    {
        public IntReference ShieldStrengthIncrease;
    } 
}
