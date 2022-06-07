using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute
{
    using Stat;

    public class DefenseAttribute : Attribute
    {
        public readonly ResistanceStat resistanceStat = new ResistanceStat();
        public readonly FortitudeStat fortitudeStat = new FortitudeStat();
        public readonly ResilienceStat resilienceStat = new ResilienceStat();

        public override void Initialize()
        {
            base.Initialize();
            resistanceStat.Initialize(this);
            fortitudeStat.Initialize(this);
            resilienceStat.Initialize(this);
            stats = new Stat.Stat[3];
            stats[0] = resistanceStat;
            stats[1] = fortitudeStat;
            stats[2] = resilienceStat;
        }
    } 
}
