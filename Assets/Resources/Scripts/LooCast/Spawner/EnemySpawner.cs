using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Spawner
{
    using Enemy;
    using Spawner.Data;
    using Data.Runtime;

    public class EnemySpawner : Spawner
    {
        public EnemySpawnerData Data;

        public float SpawnDelay { get; protected set; }
        public float SpawnTimer { get; protected set; }
        public int MaxEnemies { get; protected set; }
        public GameObject Prefab { get; protected set; }
        public List<Enemy> SpawnedEnemies { get; protected set; }

        private void Awake()
        {
            Initialize();
        }

        public override void Initialize()
        {
            SpawnDelay = Data.BaseSpawnDelay.Value;
            SpawnTimer = 0.0f;
            MaxEnemies = Data.BaseMaxEnemies.Value;
            Prefab = Enemy.DataPrefab;
            SpawnedEnemies = new List<Enemy>();
        }

        protected override void OnPauseableUpdate()
        {
            SpawnTimer += Time.deltaTime;

            if (SpawnTimer >= SpawnDelay && SpawnedEnemies.Count < MaxEnemies)
            {
                SpawnTimer = 0.0f;
                GameObject spawnedObject = Instantiate(Prefab, (Vector3)(UnityEngine.Random.insideUnitCircle * 50.0f) + transform.position, Quaternion.identity, null);
                Enemy spawnedEnemy = spawnedObject.GetComponent<Enemy>();
                SpawnedEnemies.Add(spawnedEnemy);
                spawnedEnemy.OnKilled.AddListener( () => { SpawnedEnemies.Remove(spawnedEnemy); } );
            }
        }
    }
}
