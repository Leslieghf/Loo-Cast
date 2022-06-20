using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Station
{
    [CreateAssetMenu(fileName = "EnemyStationData", menuName = "Data/Station/EnemyStationData", order = 0)]
    public class EnemyStationData : StationData
    {
        public FloatReference BaseExperienceDropChance;
        public FloatReference BaseExperienceDropAmount;
        public GameObject ExperienceOrbPrefab;
    } 
}
