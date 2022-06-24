using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "QuicknessStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/QuicknessStatRuntimeData", order = 0)]
    public sealed class QuicknessStatRuntimeData : StatRuntimeData
    {
        public FloatReference AttackDelayMultiplier;
    } 
}
