using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute.Stat
{
    public class BrawnStat : Stat
    {
        public int armorPenetrationIncrease { get { return GetLevel(); } }

        public override string ValueToString()
        {
            return $"+{GetLevel()}";
        }
    } 
}
