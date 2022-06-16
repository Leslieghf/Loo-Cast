using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Station
{
    public class StationData : ScriptableObject
    {
        public FloatReference BaseMaxHealth;
        public FloatReference BaseRegeneration;
        public IntReference BaseDefense;
    } 
}
