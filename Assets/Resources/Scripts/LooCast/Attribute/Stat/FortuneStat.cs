using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute.Stat
{
    public class FortuneStat : Stat
    {
        public float positiveEventChanceMultiplier { get { return 1 + (GetLevel() * 0.05f); } }

        public override string ValueToString()
        {
            return $"+{GetLevel() * 5}%";
        }
    } 
}
