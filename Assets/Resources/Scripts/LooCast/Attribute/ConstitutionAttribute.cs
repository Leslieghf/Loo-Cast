using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute
{
    using Stat;

    public class ConstitutionAttribute : Attribute
    {
        public readonly StaminaStat staminaStat = new StaminaStat();
        public readonly EnduranceStat enduranceStat = new EnduranceStat();
        public readonly VitalityStat vitalityStat = new VitalityStat();
        public readonly RecoveryStat recoveryStat = new RecoveryStat();

        public override void Initialize()
        {
            base.Initialize();
            staminaStat.Initialize(this);
            enduranceStat.Initialize(this);
            vitalityStat.Initialize(this);
            recoveryStat.Initialize(this);
            stats = new Stat.Stat[4];
            stats[0] = staminaStat;
            stats[1] = enduranceStat;
            stats[2] = vitalityStat;
            stats[3] = recoveryStat;
        }
    } 
}
