using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "IntellectStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/IntellectStatRuntimeData", order = 0)]
    public sealed class IntellectStatRuntimeData : StatRuntimeData
    {
        public FloatReference ExperienceMultiplier;
    } 
}
