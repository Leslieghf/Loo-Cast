using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Spawner
{
    using Util;
    using Enemy;

    public class EnemySpawner : Spawner
    {
        public float spawnDelay { get; protected set; }
        public float spawnTimer { get; protected set; }
        public int maxEnemies { get; protected set; }
        public GameObject prefab { get; protected set; }
        public List<Enemy> spawnedEnemies { get; protected set; }

        public override void Initialize()
        {
            spawnDelay = 1.0f;
            spawnTimer = 0.0f;
            maxEnemies = 3;
            prefab = Resources.Load<GameObject>("Prefabs/SmolEnemy");
            spawnedEnemies = new List<Enemy>();
        }

        protected override void Cycle()
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnDelay && spawnedEnemies.Count < maxEnemies)
            {
                spawnTimer = 0.0f;
                GameObject spawnedObject = Instantiate(prefab, (Vector3)(UnityEngine.Random.insideUnitCircle * 50.0f) + transform.position, Quaternion.identity, null);
                Enemy spawnedEnemy = spawnedObject.GetComponent<Enemy>();
                spawnedEnemy.Initialize();
                spawnedEnemies.Add(spawnedEnemy);
                spawnedEnemy.onKilled.AddListener( () => { spawnedEnemies.Remove(spawnedEnemy); } );
            }
        }
    }
}
