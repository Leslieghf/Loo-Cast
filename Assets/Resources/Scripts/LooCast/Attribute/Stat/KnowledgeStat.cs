using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute.Stat
{
    public class KnowledgeStat : Stat
    {
        public float levelExperienceMaxMultiplier { get { return 1.75f - (GetLevel() * 0.05f); } }

        public override string ValueToString()
        {
            return $"-{GetLevel() * 5}%";
        }
    } 
}
