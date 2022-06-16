using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Health
{
    public class EnemyStationHealth : StationHealth
    {
        public override void Kill()
        {
            base.Kill();

            Debug.Log("Move XP and Magnet Drop Functionality from StationHealth.cs to here");
            //Move XP and Magnet Drop Functionality from StationHealth.cs to here
        }
    } 
}
