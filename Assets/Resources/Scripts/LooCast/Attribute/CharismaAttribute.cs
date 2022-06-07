using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute
{
    using Stat;

    public class CharismaAttribute : Attribute
    {
        public readonly PresenceStat presenceStat = new PresenceStat();
        public readonly CharmStat charmStat = new CharmStat();
        public readonly SocialStat socialStat = new SocialStat();

        public override void Initialize()
        {
            base.Initialize();
            presenceStat.Initialize(this);
            charmStat.Initialize(this);
            socialStat.Initialize(this);
            stats = new Stat.Stat[3];
            stats[0] = presenceStat;
            stats[1] = charmStat;
            stats[2] = socialStat;
        }
    } 
}
