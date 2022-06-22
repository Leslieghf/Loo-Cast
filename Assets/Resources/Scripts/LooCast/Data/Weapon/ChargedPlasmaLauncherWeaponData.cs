using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Data.Weapon
{
    [CreateAssetMenu(fileName = "ChargedPlasmaLauncherWeaponData", menuName = "Data/Weapon/ChargedPlasmaLauncherWeaponData", order = 0)]
    public sealed class ChargedPlasmaLauncherWeaponData : WeaponData
    {
        public FloatReference ArcLifetime;
        public FloatReference ArcInitialWidth;
        public FloatReference ArcWidthMultiplier;
        public FloatReference ArcMinWidth;
        public IntReference ArcBranchAttempts;
        public FloatReference MinSpreadDistance;
        public FloatReference MinSpreadDistanceMultiplier;
        public FloatReference MaxSpreadDistance;
        public FloatReference MaxSpreadDistanceMultiplier;
        public FloatReference MinSpreadAngle;
        public FloatReference MinSpreadAngleMultiplier;
        public FloatReference MaxSpreadAngle;
        public FloatReference MaxSpreadAngleMultiplier;
        public FloatReference SpreadChance;
        public FloatReference SpreadChanceMultiplier;
        public FloatReference MinBranchDistance;
        public FloatReference MinBranchDistanceMultiplier;
        public FloatReference MaxBranchDistance;
        public FloatReference MaxBranchDistanceMultiplier;
        public FloatReference MinBranchAngle;
        public FloatReference MinBranchAngleMultiplier;
        public FloatReference MaxBranchAngle;
        public FloatReference MaxBranchAngleMultiplier;
        public FloatReference BranchChance;
        public FloatReference BranchChanceMultiplier;
        public IntReference MaxRecursionDepth;
    } 
}
