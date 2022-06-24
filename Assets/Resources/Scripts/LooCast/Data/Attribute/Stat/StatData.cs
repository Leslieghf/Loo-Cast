using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Attribute.Stat
{
    public abstract class StatData : ScriptableObject
    {
        public StringReference StatValueFormula;
        public StringReference EffectValueFormula;
    } 
}
