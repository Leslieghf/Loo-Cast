using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "FortitudeStatData", menuName = "Data/Runtime/Attribute/Stat/FortitudeStatData", order = 0)]
    public sealed class FortitudeStatData : StatData
    {
        public FloatReference EnergyConsumptionMultiplier;
    } 
}
