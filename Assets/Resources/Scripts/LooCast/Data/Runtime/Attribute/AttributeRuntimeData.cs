using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Runtime.Attribute
{
    public abstract class AttributeRuntimeData : ScriptableObject
    {
        public IntReference Level;
        public IntReference MaxLevel;
    } 
}
