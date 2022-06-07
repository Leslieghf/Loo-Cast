using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute.Stat
{
    public class EgoStat : Stat
    {
        public float damageReflection { get { return GetLevel() * 0.1f; } }

        public override string ValueToString()
        {
            return $"{GetLevel() * 10}%";
        }
    } 
}
