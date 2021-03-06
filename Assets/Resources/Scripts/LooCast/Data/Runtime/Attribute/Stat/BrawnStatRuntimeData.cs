using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "BrawnStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/BrawnStatRuntimeData", order = 0)]
    public sealed class BrawnStatRuntimeData : StatRuntimeData
    {
        public IntReference ArmorPenetration;
    } 
}
