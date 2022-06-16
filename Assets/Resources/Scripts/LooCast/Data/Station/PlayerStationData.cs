using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Station
{
    [CreateAssetMenu(fileName = "PlayerStationData", menuName = "Data/Station/PlayerStationData", order = 0)]
    public class PlayerStationData : StationData
    {
        public FloatReference TargetingRadius;
    } 
}
