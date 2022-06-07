using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute.Stat
{
    public class ResolveStat : Stat
    {
        public int piercingIncrease { get { return GetLevel(); } }

        public override string ValueToString()
        {
            return $"+{GetLevel()}";
        }
    } 
}
