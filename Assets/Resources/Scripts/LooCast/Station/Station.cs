using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Station
{
    using Util;
    using Health;
    using Attribute.Stat;

    [RequireComponent(typeof(StationHealth)), DisallowMultipleComponent]
    public abstract class Station : ExtendedMonoBehaviour
    {
        public readonly static List<Station> stations = new List<Station>();
        public StationHealth Health { get; private set; }

        protected float baseMaxHealth = 10000.0f;
        protected float baseRegeneration = 100.0f;
        protected int baseDefense = 500;

        public virtual void Initialize()
        {
            stations.Add(this);

            Health = GetComponent<StationHealth>();
            Health.Initialize(
                maxHealth: baseMaxHealth,
                regenerationAmount: baseRegeneration,
                defense: baseDefense
                );
        }

        public virtual void Kill()
        {
            stations.Remove(this);
            Destroy(gameObject);
        }
    } 
}
