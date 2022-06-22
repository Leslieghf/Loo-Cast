using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Health
{
    [CreateAssetMenu(fileName = "EnemyHealthData", menuName = "Data/Health/EnemyHealthData", order = 0)]
    public class EnemyHealthData : StatData
    {
        public FloatReference BaseExperienceDropChance;
        public FloatReference BaseMagnetDropChance;
        public FloatReference BaseExperienceDropAmount;
        public GameObject ExperienceOrbPrefab;
        public GameObject MagnetOrbPrefab;
    } 
}
