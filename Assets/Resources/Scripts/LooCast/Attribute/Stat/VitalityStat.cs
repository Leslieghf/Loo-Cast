using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;

namespace LooCast.Attribute.Stat
{
    public class VitalityStat : Stat
    {
        public float HealthMultiplier
        {
            get
            {
                float.TryParse(new DataTable().Compute($"1 + {Level}", "").ToString(), out float value);
                return value;
            }
        }

        public override string ValueToString()
        {
            return $"+{new DataTable().Compute($"{Level} * 100", "")}%";
        }
    }
}