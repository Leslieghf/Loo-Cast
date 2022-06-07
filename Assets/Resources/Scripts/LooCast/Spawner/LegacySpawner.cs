using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LooCast.Spawner
{
    using Util;
    using Experience;
    using Enemy;

    public class LegacySpawner : ExtendedMonoBehaviour
    {
        public bool active = true;
        public float spawnDelay;
        [Range(1, 100)]
        public int spawnChance;
        public int enemiesCount = 0;
        public int maxEnemies = 0;
        public static float difficulty 
        { 
            get {
                float difficulty;
                if (!PlayerPrefs.HasKey("Difficulty"))
                {
                    PlayerPrefs.SetFloat("Difficulty", 1.0f);
                }
                difficulty = PlayerPrefs.GetFloat("Difficulty");
                return difficulty;
            }
        }
        private string[] enemyNames;
        private List<GameObject> enemyPrefabs;
        private float nextFire = 0.0f;
        private float timer = 0.0f;
        private System.Random random = new System.Random(-DateTime.Now.Millisecond);
        private int maxSpawnDistance = 5;
        private Experience playerExperience;
        private float gameTimer = 0.0f;

        public virtual void Initialize()
        {
            enemyNames = new string[] { "SmolEnemy" };
            enemyPrefabs = new List<GameObject>();
            foreach (string enemyName in enemyNames)
            {
                enemyPrefabs.Add(Resources.Load<GameObject>("Prefabs/" + enemyName));
            }
            
            playerExperience = GameObject.FindGameObjectWithTag("Player").GetComponent<Experience>();
        }

        protected override void Cycle()
        {
            timer += Time.deltaTime;
            gameTimer += Time.deltaTime;
            if (gameTimer >= 30.0f)
            {
                gameTimer = 0.0f;
                maxEnemies += (int)((playerExperience.level + 1) * difficulty);
            }

            if (timer > nextFire)
            {
                nextFire = timer + spawnDelay;

                if (random.Next(100 / spawnChance) == 0)
                {
                    SpawnEnemy();
                }

                nextFire = nextFire - timer;
                timer = 0.0f;
            }
        }

        private void SpawnEnemy()
        {
            if (!active)
            {
                return;
            }
            if (enemiesCount >= maxEnemies)
            {
                return;
            }
            if (enemyNames == null && enemyNames.Length == 0)
            {
                return;
            }
            if (enemyPrefabs == null && enemyPrefabs.Count == 0)
            {
                return;
            }

            float randomAngle = UnityEngine.Random.Range(0.0f, 360.0f);

            Vector2 minPos = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f));
            Vector2 maxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 1, Screen.height - 1));
            Vector2 randVec = new Vector2(random.Next(maxSpawnDistance) + (maxPos.x), random.Next(maxSpawnDistance) + (maxPos.y));

            if (random.NextDouble() >= 0.5)
            {
                randVec.x = RandomFromRange((int)(minPos.x - randVec.x), (int)(maxPos.x + randVec.x));
                if (random.NextDouble() >= 0.5)
                {
                    randVec.y = RandomFromRange((int)(minPos.y - randVec.y), (int)(maxPos.y + randVec.y));
                }
            }

            GameObject enemyObject = Instantiate(enemyPrefabs[random.Next(enemyPrefabs.Count - 1)]);
            enemyObject.transform.position = randVec;
            Enemy enemy = enemyObject.GetComponent<Enemy>();
            enemy.Initialize();
            enemiesCount++;
        }

        private int RandomFromRange(int x, int y)
        {
            if (x < y)
            {
                return random.Next(x, y);
            }
            else
            {
                return random.Next(y, x);
            }
        }
    } 
}
