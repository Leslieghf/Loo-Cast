using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute.Stat
{
    public class PowerStat : Stat
    {
        public float knockbackMultiplier { get { return GetLevel() * 0.1f; } }

        public override string ValueToString()
        {
            return $"+{GetLevel() * 10}%";
        }
    }
}