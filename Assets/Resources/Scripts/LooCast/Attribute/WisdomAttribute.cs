using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Attribute
{
    using Stat;

    public class WisdomAttribute : Attribute
    {
        public readonly SpiritStat spiritStat = new SpiritStat();
        public readonly WitsStat witsStat = new WitsStat();
        public readonly PsycheStat psycheStat = new PsycheStat();
        public readonly SenseStat senseStat = new SenseStat();

        public override void Initialize()
        {
            base.Initialize();
            spiritStat.Initialize(this);
            witsStat.Initialize(this);
            psycheStat.Initialize(this);
            senseStat.Initialize(this);
            stats = new Stat.Stat[4];
            stats[0] = spiritStat;
            stats[1] = witsStat;
            stats[2] = psycheStat;
            stats[3] = senseStat;
        }
    } 
}
