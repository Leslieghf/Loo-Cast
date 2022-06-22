using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "QuicknessStatData", menuName = "Data/Runtime/Attribute/Stat/QuicknessStatData", order = 0)]
    public sealed class QuicknessStatData : StatData
    {
        public FloatReference AttackDelayMultiplier;
    } 
}
