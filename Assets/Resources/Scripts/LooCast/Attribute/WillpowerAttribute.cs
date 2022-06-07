using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute
{
    using Stat;

    public class WillpowerAttribute : Attribute
    {
        public readonly SanityStat sanityStat = new SanityStat();
        public readonly PersonalityStat personalityStat = new PersonalityStat();
        public readonly EgoStat egoStat = new EgoStat();
        public readonly ResolveStat resolveStat = new ResolveStat();

        public override void Initialize()
        {
            base.Initialize();
            sanityStat.Initialize(this);
            personalityStat.Initialize(this);
            egoStat.Initialize(this);
            resolveStat.Initialize(this);
            stats = new Stat.Stat[4];
            stats[0] = sanityStat;
            stats[1] = personalityStat;
            stats[2] = egoStat;
            stats[3] = resolveStat;
        }
    } 
}
