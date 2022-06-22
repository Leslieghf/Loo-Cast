using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "BodyStatData", menuName = "Data/Runtime/Attribute/Stat/BodyStatData", order = 0)]
    public sealed class BodyStatData : StatData
    {
        public FloatReference EnergyMultiplier;
    } 
}
