using System;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Enemy.Data
{
    using Health;

    [CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Enemy/EnemyData", order = 0)]
    public class EnemyData : ScriptableObject
    {
        public EnemyHealthData HealthData;
        public FloatReference ContactDamage;
    }
}
