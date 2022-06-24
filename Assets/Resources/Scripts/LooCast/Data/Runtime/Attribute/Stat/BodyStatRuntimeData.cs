using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "BodyStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/BodyStatRuntimeData", order = 0)]
    public sealed class BodyStatRuntimeData : StatRuntimeData
    {
        public FloatReference EnergyMultiplier;
    } 
}
