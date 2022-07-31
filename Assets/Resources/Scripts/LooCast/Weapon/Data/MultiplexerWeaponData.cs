using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Weapon.Data
{
    [CreateAssetMenu(fileName = "MultiplexerWeaponData", menuName = "Data/Weapon/MultiplexerWeaponData", order = 0)]
    public sealed class MultiplexerWeaponData : WeaponData
    {
        public IntReference BaseMaxTargets;
        public IntReference BaseMaxFragments;
        public IntReference BaseFragmentArmorPenetration;
        public BoolReference IsTargetSeeking;
        public StringReference FragmentPrefabResourcePath;
    } 
}
