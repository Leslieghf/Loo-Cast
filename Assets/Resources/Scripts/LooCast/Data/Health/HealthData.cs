using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Health
{
    public class StatData : ScriptableObject
    {
        public FloatReference BaseMaxHealth;
        public FloatReference BaseRegenerationAmount;
        public IntReference BaseDefense;
    } 
}
