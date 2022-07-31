using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Health.Data
{
    [CreateAssetMenu(fileName = "EnemyHealthData", menuName = "Data/Health/EnemyHealthData", order = 0)]
    public class EnemyHealthData : HealthData
    {
        public FloatReference BaseExperienceDropChance;
        public FloatReference BaseMagnetDropChance;
        public FloatReference BaseExperienceDropAmount;
        public GameObject ExperienceOrbPrefab;
        public GameObject MagnetOrbPrefab;
    } 
}
