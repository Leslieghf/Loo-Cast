using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute
{
    using Stat;

    public class LuckAttribute : Attribute
    {
        public readonly FateStat fateStat = new FateStat();
        public readonly ChanceStat chanceStat = new ChanceStat();
        public readonly FortuneStat fortuneStat = new FortuneStat();

        public override void Initialize()
        {
            base.Initialize();
            fateStat.Initialize(this);
            chanceStat.Initialize(this);
            fortuneStat.Initialize(this);
            stats = new Stat.Stat[3];
            stats[0] = fateStat;
            stats[1] = chanceStat;
            stats[2] = fortuneStat;
        }
    } 
}
