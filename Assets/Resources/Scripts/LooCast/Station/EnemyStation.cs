using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Station
{
    using Spawner;
    using Health;
    using Data.Station;

    [RequireComponent(typeof(EnemyStationHealth))]
    public class EnemyStation : Station
    {
        public EnemyStationData Data;
        public EnemyStationHealth Health { get; protected set; }
        public EnemySpawner Spawner { get; protected set; }

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            Initialize(Data);

            Health = GetComponent<EnemyStationHealth>();
            Health.Initialize(Data.HealthData);

            Spawner = GetComponentInChildren<EnemySpawner>();
            Spawner.Initialize();
        }
    } 
}
