using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute.Stat
{
    [CreateAssetMenu(fileName = "FortitudeStatRuntimeData", menuName = "Data/Runtime/Attribute/Stat/FortitudeStatRuntimeData", order = 0)]
    public sealed class FortitudeStatRuntimeData : StatRuntimeData
    {
        public FloatReference EnergyConsumptionMultiplier;
    } 
}
