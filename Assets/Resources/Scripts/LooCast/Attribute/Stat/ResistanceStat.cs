using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute.Stat
{
    public class ResistanceStat : Stat
    {
        public int defenseIncrease { get { return GetLevel() * 5; } }

        public override string ValueToString()
        {
            return $"+{GetLevel() * 5}";
        }
    } 
}
