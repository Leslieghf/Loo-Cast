using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Station
{
    using Target;
    using Weapon;
    using Spawner;

    public class EnemyStation : Station
    {
        public EnemySpawner spawner { get; protected set; }

        public override void Initialize()
        {
            base.Initialize();

            spawner = GetComponentInChildren<EnemySpawner>();
            spawner.Initialize();
        }
    } 
}
