using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute.Stat
{
    public class QuicknessStat : Stat
    {
        public float attackDelayMultiplier { get { return 1 - (GetLevel() * 0.075f); } }

        public override string ValueToString()
        {
            return $"-{GetLevel() * 7.5f}%";
        }
    } 
}
