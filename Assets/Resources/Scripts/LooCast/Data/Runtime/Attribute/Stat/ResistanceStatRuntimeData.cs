using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "ResistanceStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/ResistanceStatRuntimeData", order = 0)]
    public sealed class ResistanceStatRuntimeData : StatRuntimeData
    {
        public IntReference DefenseIncrease;
    } 
}
