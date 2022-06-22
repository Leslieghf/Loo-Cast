using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "KnowledgeStatData", menuName = "Data/Runtime/Attribute/Stat/KnowledgeStatData", order = 0)]
    public sealed class KnowledgeStatData : StatData
    {
        public FloatReference LevelExperienceMaxMultiplier;
    } 
}
