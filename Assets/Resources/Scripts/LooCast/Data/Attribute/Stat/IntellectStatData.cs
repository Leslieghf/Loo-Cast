using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "IntellectStatData", menuName = "Data/Runtime/Attribute/Stat/IntellectStatData", order = 0)]
    public sealed class IntellectStatData : StatData
    {
        public FloatReference ExperienceMultiplier;
    } 
}
