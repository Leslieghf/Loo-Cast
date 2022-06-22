using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "BrawnStatData", menuName = "Data/Runtime/Attribute/Stat/BrawnStatData", order = 0)]
    public sealed class BrawnStatData : StatData
    {
        public IntReference ArmorPenetration;
    } 
}
