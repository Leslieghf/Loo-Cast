using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Station
{
    using Util;
    using Health;
    using Health.Data;
    using Station.Data;
    using Data.Runtime;

    [DisallowMultipleComponent]
    public abstract class Station : ExtendedMonoBehaviour
    {
        [SerializeField]
        private StationRuntimeSet runtimeSet;

        public void Initialize(StationData data)
        {
            runtimeSet.Add(this);
        }

        public void Kill()
        {
            runtimeSet.Remove(this);
            Destroy(gameObject);
        }
    } 
}
