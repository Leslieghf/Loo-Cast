using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Spawner
{
    using Data.Runtime;

    [CreateAssetMenu(fileName = "EnemySpawnerData", menuName = "Data/Spawner/EnemySpawnerData", order = 0)]
    public sealed class EnemySpawnerData : SpawnerData
    {
        public FloatReference BaseSpawnDelay;
        public IntReference BaseMaxEnemies;
        public GameObject EnemyPrefab;
    } 
}
