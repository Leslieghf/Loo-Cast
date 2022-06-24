using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "KnowledgeStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/KnowledgeStatRuntimeData", order = 0)]
    public sealed class KnowledgeStatRuntimeData : StatRuntimeData
    {
        public FloatReference LevelExperienceMaxMultiplier;
    } 
}
