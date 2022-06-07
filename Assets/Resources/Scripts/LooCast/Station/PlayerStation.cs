using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Station
{
    using Target;
    using Weapon;

    [RequireComponent(typeof(Targeting), typeof(MultiplexerWeapon))]
    public class PlayerStation : Station
    {
        //When player enters, decrease speed (acceleration inverse drag), increase energy generation, increase health regeneration
        //Revert effects, when player leaves
        //When enemy enters, target and shoot very lethal weapon, Station Defense Weapon (Good damage, incredibly high firerate)
        //Connect player and station references upon station enter, disconnect upon station exit
        public Targeting targeting { get; private set; }
        public MultiplexerWeapon defensiveWeapon { get; private set; }

        public override void Initialize()
        {
            base.Initialize();

            targeting = GetComponent<Targeting>();
            targeting.Initialize();
            targeting.radius = 50.0f;

            defensiveWeapon = GetComponent<MultiplexerWeapon>();
            defensiveWeapon.Initialize(10.0f, 0.01f, 75.0f, 1.0f, 0.25f, 150.0f, 1.0f, 1.0f, 2, 0, 1, 0, int.MaxValue, 1);
            defensiveWeapon.enabled = true;
            defensiveWeapon.attackTimer = defensiveWeapon.attackDelay;
        }
    } 
}
