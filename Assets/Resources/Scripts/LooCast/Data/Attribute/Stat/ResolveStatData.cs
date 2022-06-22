using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "ResolveStatData", menuName = "Data/Runtime/Attribute/Stat/ResolveStatData", order = 0)]
    public sealed class ResolveStatData : StatData
    {
        public IntReference PiercingIncrease;
    } 
}
