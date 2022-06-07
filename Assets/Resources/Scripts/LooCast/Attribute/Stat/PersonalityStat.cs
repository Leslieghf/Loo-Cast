using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute.Stat
{
    public class PersonalityStat : Stat
    {
        public float projectileSpeedMultiplier { get { return 1 + (GetLevel() * 0.1f); } }

        public override string ValueToString()
        {
            return $"+{GetLevel() * 10}%";
        }
    } 
}
