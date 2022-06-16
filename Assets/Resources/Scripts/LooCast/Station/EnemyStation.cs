using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Station
{
    using Spawner;
    using Health;
    using Data.Station;

    public class EnemyStation : Station
    {
        public EnemySpawner spawner { get; protected set; }

        public EnemyStationData stationData;

        private void Start()
        {
            Initialize(stationData);
        }

        public void Initialize(EnemyStationData data)
        {
            base.Initialize<EnemyStationHealth>(data);

            spawner = GetComponentInChildren<EnemySpawner>();
            spawner.Initialize();
        }
    } 
}
