using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute.Stat
{
    public class VitalityStat : Stat
    {
        public float healthMultiplier { get { return 1 + GetLevel(); } }

        public override string ValueToString()
        {
            return $"+{GetLevel() * 100}%";
        }
    }
}