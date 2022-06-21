using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Station
{
    using Util;
    using Health;
    using Data.Health;
    using Data.Station;
    using Data.Runtime;

    [RequireComponent(typeof(StationHealth)), DisallowMultipleComponent]
    public abstract class Station : ExtendedMonoBehaviour
    {
        public StationHealth Health { get; protected set; }

        [SerializeField]
        private StationRuntimeSet runtimeSet;

        public virtual void Initialize<StationHealthType>(StationData data) where StationHealthType : StationHealth
        {
            runtimeSet.Add(this);

            Health = GetComponent<StationHealthType>();
            (Health as StationHealthType).Initialize(data.HealthData);
        }

        public virtual void Kill()
        {
            runtimeSet.Remove(this);
            Destroy(gameObject);
        }
    } 
}
