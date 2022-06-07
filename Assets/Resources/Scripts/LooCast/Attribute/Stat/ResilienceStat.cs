using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute.Stat
{
    public class ResilienceStat : Stat
    {
        public int shieldStrengthIncrease { get { return GetLevel(); } }

        public override string ValueToString()
        {
            return $"+{GetLevel()}";
        }
    } 
}
