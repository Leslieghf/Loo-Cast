using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Generator
{
    using Random;
    using Station;
    using Data.Station;

    public class PlayerStationGenerator : Generator
    {
        public int stationCount { get; protected set; }
        public GameObject prefab { get; protected set; }

        public override void Initialize()
        {
            stationCount = 3;
            prefab = Resources.Load<GameObject>("Prefabs/EnemyStation");
            Generate();
        }

        public override void Generate()
        {
            for (int i = 0; i < stationCount; i++)
            {
                Vector2 potentialSpawnPosition = Random.InsideUnitCircle() * 500.0f;
                GameObject stationObject = Instantiate(prefab, potentialSpawnPosition, Quaternion.identity, null);
                PlayerStation station = stationObject.GetComponent<PlayerStation>();
            }
        }
    } 
}
